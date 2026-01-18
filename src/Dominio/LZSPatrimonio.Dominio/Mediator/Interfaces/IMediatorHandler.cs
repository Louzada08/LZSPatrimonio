using LZSPatrimonio.Dominio.Mensagens;
using LZSPatrimonio.Dominio.Validacao;

namespace LZSPatrimonio.Dominio.Mediator.Interfaces;

public interface IMediatorHandler
{
    public Task PublishEvent<T>(T evnt) where T : Event;
    public Task<ColecaoResultadoValidacao> SendCommand<T>(T command) where T : Command;
}
