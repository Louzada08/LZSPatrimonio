namespace LZSPatrimonio.Dominio.Interfaces.Base;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime? CriadoEmUtc { get; set; }
    DateTime? AtualizadoEmUtc { get; set; }
    DateTime? DeletadoEmUtc { get; set; }
}
