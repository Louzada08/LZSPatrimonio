using LZSPatrimonio.Dominio.Interfaces.Base;

namespace LZSPatrimonio.Dominio.Entities.Base;

public class BaseEntity : IBaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public BaseEntity(DateTime criadoEm) : this()
    {
        CriadoEmUtc = criadoEm;
    }

    public BaseEntity(Guid id, DateTime criadoEm)
    {
        Id = id;
        CriadoEmUtc = criadoEm;
    }

    public Guid Id { get; set; }
    public DateTime? CriadoEmUtc { get; set; }
    public DateTime? AtualizadoEmUtc { get; set; }
    public DateTime? DeletadoEmUtc { get; set; } = null;
}
