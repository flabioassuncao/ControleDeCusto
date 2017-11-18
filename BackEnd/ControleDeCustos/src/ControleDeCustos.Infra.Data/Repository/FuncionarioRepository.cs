using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(CDCContext context) : base(context)
        {
        }
    }
}
