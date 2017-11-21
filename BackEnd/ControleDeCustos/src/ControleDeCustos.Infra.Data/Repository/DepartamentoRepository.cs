using System;
using System.Collections.Generic;
using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(CDCContext context) : base(context)
        {
        }

        public IEnumerable<Departamento> ObterTodosPorFuncionario(Guid funcionarioId)
        {
            var sql = "select * from Departamentos dep " +
                        "left join Funcionarios_Departamentos fun_dep " +
                        "on dep.Id = fun_dep.DepartamentoId " +
                        "where fun_dep.FuncionarioId = @ufuncionarioId";

            var movimentacoes = Db.Database.GetDbConnection().Query<Departamento>(sql, new { ufuncionarioId = funcionarioId });

            return movimentacoes.ToList();
        }
    }
}
