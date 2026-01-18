using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace LZSPatrimonio.Infra.Data;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public async Task<int> CommitAsync()
    {
        return await base.SaveChangesAsync();
    }
}
