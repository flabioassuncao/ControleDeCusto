using System.Collections.Generic;
using System.Linq;
using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(CDCContext context) : base(context)
        {
        }


        //public override IEnumerable<Funcionario> ObterTodos()
        //{
        //    var sql = "select * from Movimentacoes mov " +
        //                    "left join Funcionarios fun " +
        //                    "on mov.FuncionarioId = fun.Id ";

        //    var funcionario = Db.Database.GetDbConnection().Query<Funcionario, FuncionarioDepartamento, Departamento, Funcionario>(sql,
        //        (fun, fundep, dep) =>
        //        {
        //            if (dep != null)
        //                fun.Departamentos = fundep;

        //            return mov;
        //        });

        //    return funcionario.ToList();
        //}


    }
}
