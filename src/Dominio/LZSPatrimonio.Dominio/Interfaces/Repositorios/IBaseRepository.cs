using LZSPatrimonio.Dominio.Entities.Base;
using System.Linq.Expressions;

namespace LZSPatrimonio.Dominio.Interfaces.Repositorios;

public interface IBaseRepository<T> : IDisposable where T : class
{
    IUnitOfWork UnitOfWork { get; }
    T Add(T entity);
    T FindById(params object[] keyValues);
    T Update(T entity);
    T Remove(T entity);
    IQueryable<T> QueryableFilter();
    IQueryable<T> QueryableFor(Expression<Func<T, bool>> criteria = null,
        bool @readonly = false, params Expression<Func<T, object>>[] includes);
}
