using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Enums;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;

public class UnidadeResposta
{
    public Guid Id { get; set; }
    public Guid UnidadeAdminstrativaId { get; set; }
    public UnidadeAdministrativa? UnidadeAdministrativa { get; set; }
    public short CodigoInterno { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sigla { get; set; } = string.Empty;
    public FundoEnum TipoFundo { get; set; }
}
