using ControleDeCustos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleDeCustos.Domain.Interfaces
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        IEnumerable<Movimentacao> ObterPorFiltros(Guid idFuncionario, string descricao);
    }
}
