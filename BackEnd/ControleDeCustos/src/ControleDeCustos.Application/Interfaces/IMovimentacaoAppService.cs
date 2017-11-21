using ControleDeCustos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ControleDeCustos.Application.Interfaces
{
    public interface IMovimentacaoAppService : IDisposable
    {
        void Registrar(MovimentacaoViewModel movimentacaoViewModel);
        IEnumerable<MovimentacaoViewModel> ObterTodos();
        IEnumerable<MovimentacaoViewModel> ObterPorFiltros(Guid idFuncionario, string descricao);
        MovimentacaoViewModel ObterPorId(Guid id);
        void Atualizar(MovimentacaoViewModel movimentacaoViewModel);
        void Excluir(Guid id);
    }
}
