
namespace LZSPatrimonio.Dominio.Mensagens;

public abstract class Messagem
{
    public string MessageType { get; protected set; }
    public Guid AggregateId { get; set; }

    protected Messagem()
    {
        MessageType = GetType().Name;
    }
}
