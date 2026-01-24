using LZSPatrimonio.Aplicacao.Comandos.Unidades.Handlers;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Dominio.Mediator;
using LZSPatrimonio.Dominio.Mediator.Interfaces;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LZSPatrimonio.Infra.IoC.InjetorServicos;

public static class MediatorInjector
{
    public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IRequestHandler<CriarUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>, UnidadeAdmComandoHandler>();
        services.AddScoped<IRequestHandler<PatchUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>, UnidadeAdmComandoHandler>();

        services.AddScoped<IRequestHandler<CriarUnidadeRequisicao, ColecaoResultadoValidacao>, UnidadeComandoHandler>();

        services.AddScoped<IRequestHandler<CriarSetorRequisicao, ColecaoResultadoValidacao>, SetorComandoHandler>();

        return services;
    }
}
