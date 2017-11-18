using ControleDeCustos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ControleDeCustos.Application.Interfaces
{
    public interface IDepartamentoAppService : IDisposable
    {
        void Registrar(DepartamentoViewModel departamentoViewModel);
        IEnumerable<DepartamentoViewModel> ObterTodos();
        DepartamentoViewModel ObterPorId(Guid id);
        void Atualizar(DepartamentoViewModel departamentoViewModel);
        void Excluir(Guid id);
    }
}
