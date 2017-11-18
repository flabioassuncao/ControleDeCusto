using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(CDCContext context) : base(context)
        {
        }
    }
}
