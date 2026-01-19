using LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;
using LZSPatrimonio.Dominio.Mediator;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;

public class CriarUnidadeAdministrativaRequisicao : Command
{
    public string Nome { get; set; } = string.Empty;
    public short CodigoInterno { get; set; } = 0;

    public override bool IsValid()
    {
        ValidationResult = new CriarUnidadeAdministrativaRequisicaoValidacao().Validate(this);
        return ValidationResult.IsValid;
    }
}
