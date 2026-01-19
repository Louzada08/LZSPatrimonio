using FluentValidation;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Validacao;

class CriarUnidadeRequisicaoValidacao : AbstractValidator<CriarUnidadeRequisicao>
{
    public CriarUnidadeRequisicaoValidacao()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório");
        RuleFor(x => x.CodigoInterno)
        .NotEmpty().WithMessage("Código é obrigatório");
        RuleFor(x => x.Sigla)
        .NotEmpty().WithMessage("Sigla é obrigatório");
        RuleFor(x => x.TipoFundo)
        .IsInEnum().WithMessage("Tipo inválido");
    }
}