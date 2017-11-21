using System;
using System.Collections.Generic;
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

       
        //var sql = "select * from Movimentacoes mov " +
        //                "left join Funcionarios fun " +
        //                "on mov.FuncionarioId = fun.Id ";

        //var funcionario = Db.Database.GetDbConnection().Query<Funcionario, Departamento, Funcionario>(sql,
        //    (fun, dep) =>
        //    {
        //        if (dep != null)
        //            fun.Departamentos = dep;

        //        return mov;
        //    });

        //    return funcionario.ToList();
    }
}
