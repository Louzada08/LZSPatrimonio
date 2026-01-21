using LZSPatrimonio.Dominio.Entities.Base;

namespace LZSPatrimonio.Dominio.Entities
{
    public class Setor : BaseEntity
    {
        public Guid UnidadeId { get; set; }
        public Unidade? Unidade { get; set; }
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string LocalFisico { get; set; } = string.Empty;
    }
}
