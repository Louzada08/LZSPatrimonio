using LZSPatrimonio.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZSPatrimonio.Infra.Mapeadores
{
    public class UnidadeMap : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("Unidade");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.CodigoInterno)
                .IsRequired()
                .HasColumnType("short")
                .HasMaxLength(5);

            builder.Property(x => x.Sigla)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.Property(x => x.UnidadeAdminstrativaId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.TipoFundo)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(x => x.UnidadeAdministrativa)
                .WithMany(u => u.Unidades)
                .HasForeignKey(x => x.UnidadeAdminstrativaId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
