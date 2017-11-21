using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Domain.Interfaces;
using ControleDeCustos.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeCustos.Infra.Data.Repository
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(CDCContext context) : base(context)
        {
        }
        
        public override IEnumerable<Movimentacao> ObterTodos()
        {
            var sql = "select * from Movimentacoes mov " +
                        "left join Funcionarios fun " +
                        "on mov.FuncionarioId = fun.Id ";

            var movimentacao = Db.Database.GetDbConnection().Query<Movimentacao, Funcionario, Movimentacao>(sql,
                (mov, fun) =>
                {
                    if (fun != null)
                        mov.Funcionario = fun;

                    return mov;
                });

            return movimentacao.ToList();
        }

        public IEnumerable<Movimentacao> ObterPorFiltros(Guid idFuncionario, string descricao)
        {

            var query = Db.Movimentacoes
                .Include(x => x.Funcionario)
                .AsQueryable();

            if(idFuncionario != Guid.Empty)
                query = query.Where(x => x.FuncionarioId == idFuncionario);

            if(descricao != null)
                query = query.Where(x => x.Descricao.Contains(descricao));

            return query.ToList();
        }
    }
}
