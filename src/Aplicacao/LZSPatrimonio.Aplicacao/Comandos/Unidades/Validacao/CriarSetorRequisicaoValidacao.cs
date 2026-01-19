using FluentValidation;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;

class CriarSetorRequisicaoValidacao : AbstractValidator<CriarSetorRequisicao>
{
    public CriarSetorRequisicaoValidacao()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório");
        RuleFor(x => x.CodigoInterno)
        .NotEmpty().WithMessage("Código é obrigatório");
        RuleFor(x => x.LocalFisico)
        .NotEmpty().WithMessage("Local Físico é obrigatório");
    }
}