namespace LZSPatrimonio.Dominio.Interfaces.Repositorios;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}
