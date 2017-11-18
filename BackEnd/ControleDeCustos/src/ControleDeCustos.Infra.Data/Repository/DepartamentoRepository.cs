using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(CDCContext context) : base(context)
        {
        }

        //public override IEnumerable<Departamento> ObterTodos()
        //{
        //    var sql = "SELECT * FROM DEPARTAMENTOS E";

        //    return Db.Database.GetDbConnection().Query<Departamento>(sql);
        //}

    }
}
