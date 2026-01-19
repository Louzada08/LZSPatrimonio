using LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Mediator;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao
{
    public class CriarSetorRequisicao : Command
    {
        public Guid UnidadeId { get; set; }
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string LocalFisico { get; set; } = string.Empty;

        public override bool IsValid()
        {
            ValidationResult = new CriarSetorRequisicaoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
