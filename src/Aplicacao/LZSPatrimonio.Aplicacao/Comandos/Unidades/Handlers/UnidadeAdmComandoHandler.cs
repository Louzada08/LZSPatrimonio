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
public class UnidadeAdmComandoHandler : CommandHandler,
    IRequestHandler<CriarUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>
{
    private readonly IMapper _mapper;
    private readonly IUnidadeAdministrativaRepository _unAdministrativaRepository;
    private readonly IUnidadeAdministrativaService _unAdministrativaService;

    public UnidadeAdmComandoHandler(IMapper mapper, IUnidadeAdministrativaService unAdministrativaService,
        IUnidadeAdministrativaRepository unAdministrativaRepository)
    {
        _mapper = mapper;
        _unAdministrativaService = unAdministrativaService;
        _unAdministrativaRepository = unAdministrativaRepository;
    }

    public async Task<ColecaoResultadoValidacao> Handle(CriarUnidadeAdministrativaRequisicao request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var unAdm = _mapper.Map<UnidadeAdministrativa>(request);

        var ret = await _unAdministrativaService.Create(unAdm);

        ValidationResult.Data = _mapper.Map<CriarUnidadeAdministrativaResposta>(ret);
        return ValidationResult;
    }

}
