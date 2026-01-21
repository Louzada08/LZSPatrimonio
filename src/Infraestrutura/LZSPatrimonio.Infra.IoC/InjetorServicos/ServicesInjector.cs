using LZSPatrimonio.Dominio.Interfaces.Servicos;
using LZSPatrimonio.Dominio.ServicosDominio;
using LZSPatrimonio.Infra.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LZSPatrimonio.Infra.IoC.InjetorServicos
{
    public static class ServicesInjector
    {
        public static IServiceCollection AddServicesInjectors(this IServiceCollection services)
        {

            services.AddScoped<AppDbContext>();
            services.AddScoped<IUnidadeAdministrativaService, UnidadeAdministrativaService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<ISetorService, SetorService>();

            return services;
        }
    }
}
