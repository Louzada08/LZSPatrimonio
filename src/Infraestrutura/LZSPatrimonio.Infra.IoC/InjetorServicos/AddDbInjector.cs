using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Infra.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace LZSPatrimonio.Infra.IoC.InjetorServicos;

public static class DbInjector
{
    public static IServiceCollection AddDbInjector(this IServiceCollection services)
    {
        services.AddScoped<IUnidadeAdministrativaRepository, UnidadeAdministrativaRepository>();
        services.AddScoped<IUnidadeRepository, UnidadeRepository>();
        services.AddScoped<ISetorRepository, SetorRepository>();

        return services;
    }
}
