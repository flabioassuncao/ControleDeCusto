using ControleDeCustos.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ControleDeCustos.Domain.Interfaces
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        IEnumerable<Departamento> ObterTodosPorFuncionario(Guid funcionarioId);
    }
}
