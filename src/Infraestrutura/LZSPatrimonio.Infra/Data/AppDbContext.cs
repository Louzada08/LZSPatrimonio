using FluentValidation.Results;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Base;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Dominio.Mediator.Interfaces;
using LZSPatrimonio.Dominio.Mensagens;
using LZSPatrimonio.Infra.Extensoes;
using LZSPatrimonio.Infra.Mapeadores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace LZSPatrimonio.Infra.Data;

public class AppDbContext : IdentityDbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<UnidadeAdministrativa> UnidadesAdministrativa { get; set; }
    public DbSet<Unidade> Unidades { get; set; }
    public DbSet<Setor> Setores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        base.OnModelCreating(modelBuilder);

        foreach (var type in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                modelBuilder.SetSoftDeleteFilter(type.ClrType);
        }

        modelBuilder.ApplyConfiguration(new UnidadeAdministrativaMap());
        modelBuilder.ApplyConfiguration(new UnidadeMap());
        modelBuilder.ApplyConfiguration(new SetorMap());
    }

    public async Task<bool> CommitAsync()
    {
        if (await base.SaveChangesAsync() <= 0)
            return false;

        await _mediatorHandler.PublishEvents(this);

        return true;
    }

    public bool DatabaseExists()
    {
        try
        {
            return Database.GetService<IRelationalDatabaseCreator>().Exists();
        }
        catch (DbException)
        {
            return false;
        }
    }

}
