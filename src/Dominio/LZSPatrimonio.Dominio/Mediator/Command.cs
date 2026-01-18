using FluentValidation.Results;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;

namespace LZSPatrimonio.Dominio.Mediator;
public abstract class Command : IRequest<ColecaoResultadoValidacao>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command() => Timestamp = DateTime.Now;

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}
