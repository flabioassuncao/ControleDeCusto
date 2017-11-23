using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ControleDeCustos.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ControleDeCustos.Application.Interfaces;
using ControleDeCustos.Domain.Interfaces;

namespace ControleDeCustos.Services.Api.Controllers
{
    //[AllowAnonymous]
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoAppService _departamentoAppService;

        public DepartamentoController(IUser user, IDepartamentoAppService departamentoAppService) : base(user)
        {
            _departamentoAppService = departamentoAppService;
        }

        [HttpGet]
        [Route("obter-todos-departamentos")]
        public IEnumerable<DepartamentoViewModel> Get()
        {
            return _departamentoAppService.ObterTodos();
        }
        
        [HttpGet]
        [Route("obter-departamento-por-id/{id:guid}")]
        public DepartamentoViewModel Get(Guid id)
        {
            return _departamentoAppService.ObterPorId(id);
        }
        
        [HttpPost]
        [Route("adicionar-departamento")]
        public void Post([FromBody]DepartamentoViewModel model)
        {
            _departamentoAppService.Registrar(model);
        }
        
        [HttpPut]
        [Route("atualizar-departamento")]
        public void Put([FromBody]DepartamentoViewModel model)
        {
            _departamentoAppService.Atualizar(model);
        }
        
        [HttpDelete]
        [Route("deletar-departamento/{id:guid}")]
        public void Delete(Guid id)
        {
            _departamentoAppService.Excluir(id);
        }
    }
}
