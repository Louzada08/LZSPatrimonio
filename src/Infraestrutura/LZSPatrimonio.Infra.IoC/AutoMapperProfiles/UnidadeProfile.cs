using AutoMapper;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;
using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Mapmto.AutoMapperProfiles;

public class UnidadeProfile : Profile
{
    public UnidadeProfile()
    {
        CreateMap<Unidade, CriarUnidadeRequisicao>().ReverseMap();
        CreateMap<Unidade, CriarUnidadeResposta>().ReverseMap();
    }
}
