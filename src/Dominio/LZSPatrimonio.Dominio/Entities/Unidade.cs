using LZSPatrimonio.Dominio.Entities.Base;
using LZSPatrimonio.Dominio.Enums;

namespace LZSPatrimonio.Dominio.Entities
{
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
}
