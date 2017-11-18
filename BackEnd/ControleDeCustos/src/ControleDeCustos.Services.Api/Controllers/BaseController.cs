using System;
using Microsoft.AspNetCore.Mvc;
using ControleDeCustos.Domain.Interfaces;

namespace ControleDeCustos.Services.Api.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        protected Guid FuncionarioId { get; set; }

        public BaseController(IUser user)
        {
            if (user.IsAuthenticated())
            {
                FuncionarioId = user.GetUserId();
            }
        }

        protected new IActionResult Response(object result, bool success, string message)
        {
            if (success)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = message
            });
        }
    }
}