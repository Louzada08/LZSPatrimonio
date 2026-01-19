using LZSPatrimonio.Dominio.Enums;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta
{
    public class CriarUnidadeResposta
    {
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public FundoEnum TipoFundo { get; set; }
    }
}
