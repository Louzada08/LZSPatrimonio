using LZSPatrimonio.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LZSPatrimonio.Infra.Mapeadores
{
    public class SetorMap : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Setor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.CodigoInterno)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(x => x.LocalFisico)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(x => x.UnidadeId)
                .IsRequired()
                .HasColumnType("uuid");

            builder.HasOne(x => x.Unidade)
                .WithMany(u => u.Setores)
                .HasForeignKey(x => x.UnidadeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
