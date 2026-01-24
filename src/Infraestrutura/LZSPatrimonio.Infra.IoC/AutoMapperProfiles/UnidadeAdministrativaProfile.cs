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

        CreateMap<UnidadeAdministrativa, UnidadeAdministrativaResposta>()
            .ForMember(x => x.Nome, r => r.MapFrom(r => r.Nome))
            .ReverseMap();

        CreateMap<UnidadeAdministrativa, PatchUnidadeAdministrativaRequisicao>()
            .ForMember(x => x.CodigoInterno, r => r.MapFrom(r => r.CodigoInterno))
            .ForMember(x => x.Nome, r => r.MapFrom(r => r.Nome))
            .ReverseMap();

    }
}
