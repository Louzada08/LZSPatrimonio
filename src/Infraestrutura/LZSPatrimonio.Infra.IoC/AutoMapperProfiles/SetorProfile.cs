using AutoMapper;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;
using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Mapmto.AutoMapperProfiles;

public class SetorProfile : Profile
{
    public SetorProfile()
    {
        CreateMap<Setor, CriarSetorRequisicao>()
            .ReverseMap();
        CreateMap<Setor, CriarSetorResposta>().ReverseMap();
    }
}
