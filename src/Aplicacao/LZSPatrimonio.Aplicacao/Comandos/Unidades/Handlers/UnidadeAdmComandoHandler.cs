using AutoMapper;
using FluentValidation.Results;
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
    IRequestHandler<CriarUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>,
    IRequestHandler<PatchUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>,
    IRequestHandler<DeleteUnidadeAdministrativaRequisicao, ColecaoResultadoValidacao>   
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

    public async Task<ColecaoResultadoValidacao> Handle(PatchUnidadeAdministrativaRequisicao request, CancellationToken cancellationToken)
    {
        var patchUnAdmGetById = await _unAdministrativaService.GetById(request.Id);

        var patchUnAdm = _mapper.Map<PatchUnidadeAdministrativaRequisicao>(patchUnAdmGetById);
        request.PatchUnidAdminRequest.ApplyTo(patchUnAdm);

        _mapper.Map(patchUnAdm, patchUnAdmGetById);
        var ret = _unAdministrativaRepository.Update(patchUnAdmGetById);
        await PersistData(_unAdministrativaRepository.UnitOfWork);

        ValidationResult.Data = _mapper.Map<UnidadeAdministrativaResposta>(ret);
        return ValidationResult;
    }

    public async Task<ColecaoResultadoValidacao> Handle(DeleteUnidadeAdministrativaRequisicao request, CancellationToken cancellationToken)
    {
        var delUnAdmGetById = await _unAdministrativaService.GetById(request.Id);

        if (!request.IsValid()) return ValidationResult;

        if (delUnAdmGetById == null)
        {
            AddError("Registro não existe.");
            return ValidationResult;
        }

        _unAdministrativaRepository.Remove(delUnAdmGetById);
        await PersistData(_unAdministrativaRepository.UnitOfWork);

        return ValidationResult;
    }
}
