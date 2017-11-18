using ControleDeCustos.Domain.Entities;
using ControleDeCustos.Infra.Data.Extensions;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCustos.Infra.Data.Mappings
{
    public class MovimentacaoMapping : EntityTypeConfiguration<Movimentacao>
    {
        public override void Map(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Descricao)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder.Property(e => e.Valor)
               .HasColumnType("decimal(5,2)")
               .IsRequired();

            builder.HasOne(e => e.Funcionario)
                .WithMany(o => o.Movimentacoes)
                .HasForeignKey(e => e.FuncionarioId);

            builder.ToTable("Movimentacoes");
        }
    }
}
