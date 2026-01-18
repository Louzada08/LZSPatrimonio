namespace LZSPatrimonio.Dominio.Interfaces.Repositorios;

public interface IServiceCommandRepository
{
    Task ExecuteCommandAsync(string command, CancellationToken cancellationToken = default);
}
