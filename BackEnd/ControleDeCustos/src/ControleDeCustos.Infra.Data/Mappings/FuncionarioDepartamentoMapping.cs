using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCustos.Infra.Data.Mappings
{
    public class FuncionarioDepartamentoMapping : EntityTypeConfiguration<FuncionarioDepartamento>
    {
        public override void Map(EntityTypeBuilder<FuncionarioDepartamento> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(e => e.Funcionario)
                .WithMany(o => o.Departamentos)
                .HasForeignKey(e => e.FuncionarioId);

            builder.HasOne(e => e.Departamento)
                .WithMany(o => o.Funcionarios)
                .HasForeignKey(e => e.DepartamentoId);

            builder.ToTable("Funcionarios_Departamentos");
        }
    }
}
