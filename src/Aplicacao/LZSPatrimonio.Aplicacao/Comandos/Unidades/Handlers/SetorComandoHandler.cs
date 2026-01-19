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
public class SetorComandoHandler : CommandHandler,
    IRequestHandler<CriarSetorRequisicao, ColecaoResultadoValidacao>
{
    private readonly IMapper _mapper;
    private readonly ISetorRepository _setorRepository;
    private readonly ISetorService _setorService;

    public SetorComandoHandler(IMapper mapper, ISetorService setorService,
        ISetorRepository setorRepository)
    {
        _mapper = mapper;
        _setorService = setorService;
        _setorRepository = setorRepository;
    }

    public async Task<ColecaoResultadoValidacao> Handle(CriarSetorRequisicao request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            ValidationResult.Errors.AddRange(request.ValidationResult.Errors);
            return ValidationResult;
        }

        var setor = _mapper.Map<Setor>(request);

        var ret = await _setorService.Create(setor);

        ValidationResult.Data = _mapper.Map<CriarSetorResposta>(ret);
        return ValidationResult;
    }

}
