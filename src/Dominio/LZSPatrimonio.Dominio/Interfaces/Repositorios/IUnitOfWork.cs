namespace LZSPatrimonio.Dominio.Interfaces.Repositorios;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    bool DatabaseExists();
}
