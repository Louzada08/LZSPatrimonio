using AutoMapper;
using FluentValidation.Results;
using LZSPatrimonio.API.Controladores.Principal;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;
using LZSPatrimonio.Aplicacao.Comandos.Unidades.Resposta;
using LZSPatrimonio.Dominio.Interfaces.Servicos;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LZSPatrimonio.API.Controladores;

[Route("api/[controller]")]
[ApiController]
public class UnidadeAdministrativaController : PrincipalController
{
    private readonly IUnidadeAdministrativaService _unAdmService;

    public UnidadeAdministrativaController(IUnidadeAdministrativaService unAdmService, 
        IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        _unAdmService = unAdmService;
    }

    // GET: api/<SuiteController>
    [HttpGet("UnidadeAdmin")]
    /// public async Task<IActionResult> GetByAll([FromQuery] CategoryFilter categoryFilter)
    public async Task<IActionResult> GetAll()
    {
        var response = await _unAdmService.GetAll();

        if (response is not null) return CustomResponse(response);

        var bag = new ColecaoResultadoValidacao();
        bag.Errors.Add(new ValidationFailure("error", "Nenhuma Unidade Administrativa encontrada"));
        return CustomResponse(bag);
    }

    // GET api/<SuiteController>/5
    [HttpGet("{Id:Guid}")]
    [ProducesResponseType(typeof(CriarUnidadeAdministrativaResposta), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CriarUnidadeAdministrativaResposta), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomerById(Guid Id)
    {
        try
        {
            var resp = _mapper.Map<CriarUnidadeAdministrativaResposta>(await _unAdmService.GetById(Id));

            if (resp is not null) return CustomResponse(resp);

            var bag = new ColecaoResultadoValidacao();
            bag.Errors.Add(new ValidationFailure("error", "Unidade Administrativa não encontrado.", StatusCodes.Status404NotFound));
            return CustomResponse(bag);
        }
        catch (Exception ex)
        {
            var bag = new ColecaoResultadoValidacao();
            bag.Errors.Add(new ValidationFailure("error", ex.Message));
            return CustomResponse(bag);
        }
    }

    [HttpPost]
    //[Authorize(Policy = "Loja")]
    [ProducesResponseType(typeof(CriarUnidadeAdministrativaResposta), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CriarUnidadeAdministrativaRequisicao command)
    {
        var response = await _mediator.Send(command);

        if (response is not null) return CustomResponse(response);

        var bag = new ColecaoResultadoValidacao();
        bag.Errors.Add(new ValidationFailure("error", "Não foi possível salvar"));
        return CustomResponse(bag);
    }


    [HttpPatch("{unAdmId:Guid}")]
    [ProducesResponseType(typeof(CriarUnidadeAdministrativaResposta), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Patch(Guid freightId, JsonPatchDocument<PatchFreightRequest> request)
    {
        var command = new PatchFreightRequest(request)
        {
            Id = freightId
        };

        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
