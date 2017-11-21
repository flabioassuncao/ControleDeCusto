using ControleDeCustos.Application.DTO;
using ControleDeCustos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ControleDeCustos.Application.Interfaces
{
    public interface IFuncionarioAppService : IDisposable
    {
        void Registrar(FuncionarioViewModel funcionarioViewModel);
        IEnumerable<FuncionarioViewModel> ObterTodos();
        IEnumerable<FuncionarioDTO> ObterTodosDTO();
        FuncionarioViewModel ObterPorId(Guid id);
        void Atualizar(FuncionarioViewModel funcionarioViewModel);
        void Excluir(Guid id);
    }
}
