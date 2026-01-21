using AutoMapper;
using LZSPatrimonio.Dominio.Entities.Base;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LZSPatrimonio.Infra.Repositorios;

public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
{
    public AppDbContext Context { get; }
    public IUnitOfWork UnitOfWork { get; set; }
    protected readonly DbSet<T> DbSet;
    private readonly IMapper _mapper;

    public BaseRepository(AppDbContext context, IMapper mapper)
    {
        Context = context;
        DbSet = Context.Set<T>();
        this.UnitOfWork = Context as IUnitOfWork;
        _mapper = mapper;
    }

    public T Add(T entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.CriadoEmUtc = DateTime.UtcNow;
            baseEntity.AtualizadoEmUtc = DateTime.UtcNow;
        }

        DbSet.Add(entity);
        return entity;
    }

    public T Remove(T entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.DeletadoEmUtc = DateTime.UtcNow;
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);
        }

        return entity;
    }

    public T FindById(params object[] ids)
    {
        return DbSet.Find(ids);
    }

    public virtual T Update(T entity)
    {
        if (entity is BaseEntity baseEntity)
        {
            baseEntity.AtualizadoEmUtc = DateTime.UtcNow;
        }

        var entry = Context.Entry(entity);
        DbSet.Attach(entity);
        entry.State = EntityState.Modified;

        return entity;
    }

    public IQueryable<T> QueryableFilter() => DbSet.AsQueryable();

    public IQueryable<T> QueryableFor(Expression<Func<T, bool>> criteria = null, bool @readonly = false, params Expression<Func<T, object>>[] includes)
    {
        if (criteria == null)
        {
            if (includes == null)
            {
                return DbSet.Where(criteria);
            }

            var queryAll = DbSet.AsQueryable();

            foreach (var include in includes)
            {
                queryAll.Include(include);
            }

            return @readonly ? queryAll.AsNoTracking() : queryAll;
        }
        var queryWhere = DbSet.Where(criteria);

        if (includes == null)
        {
            return queryWhere;
        }

        foreach (var include in includes)
        {
            queryWhere = queryWhere.Include(include);
        }

        return queryWhere;
    }

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;

        Context.Dispose();
    }

    #endregion IDisposable
}
