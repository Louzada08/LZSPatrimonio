using LZSPatrimonio.Dominio.Mediator.Interfaces;
using LZSPatrimonio.Dominio.Mensagens;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;

namespace LZSPatrimonio.Dominio.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishEvent<T>(T evnt) where T : Event
    {
        await _mediator.Publish(evnt);
    }

    public async Task<ColecaoResultadoValidacao> SendCommand<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }
}
