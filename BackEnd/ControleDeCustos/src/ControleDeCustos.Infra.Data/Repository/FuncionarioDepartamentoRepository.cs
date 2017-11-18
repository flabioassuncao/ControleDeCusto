using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class FuncionarioDepartamentoRepository : Repository<FuncionarioDepartamento>, IFuncionarioDepartamentoRepository
    {
        public FuncionarioDepartamentoRepository(CDCContext context) : base(context)
        {
        }
    }
}
