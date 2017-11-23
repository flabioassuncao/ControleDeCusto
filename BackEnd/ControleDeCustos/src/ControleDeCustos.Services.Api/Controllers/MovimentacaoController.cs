using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Application.Interfaces;
using ControleDeCustos.Application.ViewModels;

namespace ControleDeCustos.Services.Api.Controllers
{
    //[AllowAnonymous]
    public class MovimentacaoController : BaseController
    {
        private readonly IMovimentacaoAppService _movAppService;

        public MovimentacaoController(IUser user, IMovimentacaoAppService movAppService) : base(user)
        {
            _movAppService = movAppService;
        }
        
        [HttpGet]
        [Route("obter-todas-movimentacoes")]
        public IEnumerable<MovimentacaoViewModel> Get()
        {
            return _movAppService.ObterTodos();
        }
        
        [HttpGet]
        [Route("obter-movimentacao-por-id/{id:guid}")]
        public MovimentacaoViewModel Get(Guid id)
        {
            return _movAppService.ObterPorId(id);
        }

        [HttpGet]
        [Route("obter-movimentacao-por-filtro")]
        public IEnumerable<MovimentacaoViewModel> Get(Guid idFuncionario, string descricao)
        {
            return _movAppService.ObterPorFiltros(idFuncionario, descricao);
        }

        [HttpPost]
        [Route("adicionar-movimentacao")]
        public void Post([FromBody]MovimentacaoViewModel model)
        {
            _movAppService.Registrar(model);
        }
        
        [HttpPut]
        [Route("atualizar-movimentacao")]
        public void Put([FromBody]MovimentacaoViewModel model)
        {
            _movAppService.Atualizar(model);
        }
        
        [HttpDelete]
        [Route("deletar-movimentacao/{id:guid}")]
        public void Delete(Guid id)
        {
            _movAppService.Excluir(id);
        }
    }
}
