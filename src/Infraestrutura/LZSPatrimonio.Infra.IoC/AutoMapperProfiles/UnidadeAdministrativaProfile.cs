using AutoMapper;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;
using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Infra.IoC.AutoMapperProfiles;

public class UnidadeAdministrativaProfile : Profile
{
    public UnidadeAdministrativaProfile()
    {
        CreateMap<UnidadeAdministrativa, CriarUnidadeAdministrativaRequisicao>()
            .ReverseMap();
        CreateMap<UnidadeAdministrativa, CriarUnidadeAdministrativaResposta>().ReverseMap();
    }
}
