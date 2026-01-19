using LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Enums;
using LZSPatrimonio.Dominio.Mediator;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao
{
    public class CriarUnidadeRequisicao : Command
    {
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public FundoEnum TipoFundo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CriarUnidadeRequisicaoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
