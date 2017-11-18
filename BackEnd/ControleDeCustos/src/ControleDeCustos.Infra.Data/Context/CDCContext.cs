using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Infra.Data.Extensions;
using ControleDeCustos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ControleDeCustos.Infra.Data.Context
{
    public class CDCContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<FuncionarioDepartamento> FuncionariosDepartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new DepartamentoMapping());
            modelBuilder.AddConfiguration(new FuncionarioDepartamentoMapping());
            modelBuilder.AddConfiguration(new FuncionarioMapping());
            modelBuilder.AddConfiguration(new MovimentacaoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
