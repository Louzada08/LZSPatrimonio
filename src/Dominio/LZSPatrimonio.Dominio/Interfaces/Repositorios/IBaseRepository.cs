using LZSPatrimonio.Dominio.Entities.Base;

namespace LZSPatrimonio.Dominio.Interfaces.Repositorios;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<T>> ObterTodosAsync();
    Task AdicionarAsync(T entity);
    Task AtualizarAsync(T entity);
    Task RemoverAsync(T entity);
}
