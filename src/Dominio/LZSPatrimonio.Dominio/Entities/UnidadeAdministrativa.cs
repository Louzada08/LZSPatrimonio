using LZSPatrimonio.Dominio.Entities.Base;
using LZSPatrimonio.Dominio.Enums;

namespace LZSPatrimonio.Dominio.Entities;

public class UnidadeAdministrativa : BaseEntity, IAggregateRoot
{
    public short CodigoInterno { get; set; } = 0;
    public string Nome { get; set; } = string.Empty;
    public ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
}
