using MediatR;

namespace LZSPatrimonio.Dominio.Mensagens;

public class Event : Messagem, INotification
{
    public DateTime Timestamp { get; private set; }

    public Event()
    {
        Timestamp = DateTime.Now;
    }
}
