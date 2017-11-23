using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeCustos.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ControleDeCustos.Infra.Identity.Models;
using ControleDeCustos.Infra.Identity.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ControleDeCustos.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ControleDeCustos.Services.Api.Controllers
{

    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFuncionarioAppService _funcService;

        private readonly JwtTokenOptions _jwtTokenOptions;

        public AccountController(IUser user,
                                 IFuncionarioAppService funcService,
                                 IOptions<JwtTokenOptions> jwtTokenOptions,
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager) : base(user)
        {
            _funcService = funcService;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenOptions = jwtTokenOptions.Value;

            ThrowIfInvalidOptions(_jwtTokenOptions);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        [HttpPost]
        [AllowAnonymous]
        [Route("nova-conta")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model, int version)
        {
            if (version == 2)
            {
                return Response(model, false, "API não disponivel");
            }

            if (!ModelState.IsValid) return Response(model, false, "Preecher todos os campos");
            
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            
            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                try
                {
                    var response = GerarTokenUsuario(new LoginViewModel { Email = model.Email, Senha = model.Senha });
                    return Response(response, true, "Funcionario criado com sucesso!");
                }
                catch (Exception) {
                    await _userManager.DeleteAsync(user);
                    return Response(model, false, "Erro ao registrar usuario!");
                }
            }

            await _userManager.DeleteAsync(user);
            return Response(model, false, "Erro ao registrar usuario!");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Response(model, false, "Informar login e senha");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, false, true);

            if (result.Succeeded)
            {
                
                var response = GerarTokenUsuario(model);
                return Response(response, true, "");
            }
            
            return Response(model, false, "Falha ao realizar login");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("verificar-autenticacao")]
        public IActionResult VerificarUser()
        {
            if(User.Identity.IsAuthenticated)
                return Response(new object(), true, "");

            return Response(new object(), false, "Falha ao realizar login");
        }

        private async Task<object> GerarTokenUsuario(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64));

            var jwt = new JwtSecurityToken(
                  issuer: _jwtTokenOptions.Issuer,
                  audience: _jwtTokenOptions.Audience,
                  claims: userClaims,
                  notBefore: _jwtTokenOptions.NotBefore,
                  expires: _jwtTokenOptions.Expiration,
                  signingCredentials: _jwtTokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_jwtTokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    id = user.Id,
                    email = user.Email,
                    claims = userClaims.Select(c => new { c.Type, c.Value })
                }
            };

            return response;
        }

        private static void ThrowIfInvalidOptions(JwtTokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtTokenOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.JtiGenerator));
            }
        }
    }
}