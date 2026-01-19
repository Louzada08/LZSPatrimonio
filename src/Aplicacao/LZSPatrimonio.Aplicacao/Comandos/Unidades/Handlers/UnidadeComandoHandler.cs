using AutoMapper;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Dominio.Interfaces.Servicos;
using LZSPatrimonio.Dominio.Mensagens;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Handlers;
public class UnidadeComandoHandler : CommandHandler,
    IRequestHandler<CriarUnidadeRequisicao, ColecaoResultadoValidacao>
{
    private readonly IMapper _mapper;
    private readonly IUnidadeRepository _unRepository;
    private readonly IUnidadeService _unService;

    public UnidadeComandoHandler(IMapper mapper, IUnidadeService unService,
        IUnidadeRepository unRepository)
    {
        _mapper = mapper;
        _unService = unService;
        _unRepository = unRepository;
    }

    public async Task<ColecaoResultadoValidacao> Handle(CriarUnidadeRequisicao request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var unid = _mapper.Map<Unidade>(request);

        var ret = await _unService.Create(unid);

        ValidationResult.Data = _mapper.Map<CriarUnidadeResposta>(ret);
        return ValidationResult;
    }

}
