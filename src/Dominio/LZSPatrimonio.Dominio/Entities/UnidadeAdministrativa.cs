using LZSPatrimonio.Dominio.Entities.Base;
using LZSPatrimonio.Dominio.Enums;
using System.Collections.Generic;

namespace LZSPatrimonio.Dominio.Entities;

public class UnidadeAdministrativa : BaseEntity, IAggregateRoot
{
    public short CodigoInterno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public ICollection<Unidade> Unidades { get; set; } = new List<Unidade>();
}

public class Unidade : BaseEntity
{
    public Guid UnidadeAdminstrativaId { get; set; }
    public UnidadeAdministrativa? UnidadeAdministrativa { get; set; }
    public short CodigoInterno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
    public FundoEnum TipoFundo { get; set; }
    public ICollection<Setor> Setores { get; set; } = new List<Setor>();
}

public class Setor : BaseEntity
{
    public Guid UnidadeId { get; set; }
    public Unidade? Unidade { get; set; }
    public short CodigoInterno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string LocalFisico { get; set; } = string.Empty;
}
