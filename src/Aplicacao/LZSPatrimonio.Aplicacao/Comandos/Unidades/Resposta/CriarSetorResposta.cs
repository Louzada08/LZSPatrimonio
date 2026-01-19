namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta
{
    public class CriarSetorResposta
    {
        public Guid UnidadeId { get; set; }
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string LocalFisico { get; set; } = string.Empty;
    }
}
