using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCustos.Infra.Data.Mappings
{
    public class DepartamentoMapping : EntityTypeConfiguration<Departamento>
    {
        public override void Map(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();
            
            builder.ToTable("Departamentos");
        }
    }
}
