using LZSPatrimonio.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LZSPatrimonio.Infra.Mapeadores
{
    public class UnidadeAdministrativaMap : IEntityTypeConfiguration<UnidadeAdministrativa>
    {
        public void Configure(EntityTypeBuilder<UnidadeAdministrativa> builder)
        {
            builder.ToTable("UnidadeAdministrativa");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(u => u.CodigoInterno)
                .IsRequired()
                .HasColumnType("smallint")
                .HasMaxLength(5);
        }
    }
}
