using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Application.Interfaces;
using ControleDeCustos.Application.ViewModels;

namespace ControleDeCustos.Services.Api.Controllers
{
    [AllowAnonymous]
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioAppService _funcAppService;

        public FuncionarioController(IUser user, IFuncionarioAppService funcAppService) : base(user)
        {
            _funcAppService = funcAppService;
        }

        [HttpGet]
        [Route("obter-todos-funcionarios")]
        public IEnumerable<FuncionarioViewModel> Get()
        {
            return _funcAppService.ObterTodos();
        }
        
        [HttpGet]
        [Route("obter-funcionario-por-id/{id:guid}")]
        public FuncionarioViewModel Get(Guid id)
        {
            return _funcAppService.ObterPorId(id);
        }
        
        [HttpPost]
        [Route("adicionar-funcionario")]
        public void Post([FromBody]FuncionarioViewModel model)
        {
            _funcAppService.Registrar(model);
        }
        
        [HttpPut]
        [Route("atualizar-funcionario")]
        public void Put([FromBody]FuncionarioViewModel model)
        {
            _funcAppService.Atualizar(model);
        }
        
        [HttpDelete]
        [Route("deletar-funcionario/{id:guid}")]
        public void Delete(Guid id)
        {
            _funcAppService.Excluir(id);
        }
    }
}
