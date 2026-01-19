using FluentValidation;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;

class CriarUnidadeAdministrativaRequisicaoValidacao : AbstractValidator<CriarUnidadeAdministrativaRequisicao>
{
    public CriarUnidadeAdministrativaRequisicaoValidacao()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório");
        RuleFor(x => x.CodigoInterno)
        .NotEmpty().WithMessage("Código é obrigatório");
    }
}