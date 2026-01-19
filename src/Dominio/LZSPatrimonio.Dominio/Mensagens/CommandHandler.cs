using FluentValidation.Results;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Dominio.Validacao;

namespace LZSPatrimonio.Dominio.Mensagens;

public abstract class CommandHandler
{
    protected ColecaoResultadoValidacao ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ColecaoResultadoValidacao();
    }

    protected void AddError(string message)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
    }

    protected async Task<ColecaoResultadoValidacao> PersistData(IUnitOfWork uow)
    {
        if (!await uow.CommitAsync())
            AddError("Houve um erro ao persistir os dados");

        return ValidationResult;
    }
}
