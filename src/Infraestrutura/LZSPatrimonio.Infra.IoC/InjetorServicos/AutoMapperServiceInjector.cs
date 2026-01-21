using AutoMapper;
using LZSPatrimonio.Infra.IoC.AutoMapperProfiles;
using LZSPatrimonio.Mapmto.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace LZSPatrimonio.Infra.IoC.InjetorServicos;

public static class AutoMapperServiceInjector
{
    public static IServiceCollection AddAutoMapperInjector(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UnidadeAdministrativaProfile());
            mc.AddProfile(new UnidadeProfile());
            mc.AddProfile(new SetorProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
