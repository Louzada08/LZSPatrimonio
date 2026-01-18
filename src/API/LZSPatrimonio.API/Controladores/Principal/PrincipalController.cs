using AutoMapper;
using LZSPatrimonio.Dominio.Validacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LZSPatrimonio.API.Controladores.Principal;

[ApiController]
public class PrincipalController : Controller
{
    protected ICollection<string> _errors = new List<string>();
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;

    public PrincipalController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    protected ActionResult CustomResponse(object result = null)
    {
        if (IsOperationValid())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
           { "Mensagens", _errors.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(v => v.Errors);

        foreach (var error in errors)
        {
            AddError(error.ErrorMessage);
        }
        return CustomResponse();
    }

    protected ActionResult CustomResponse(ColecaoResultadoValidacao colecaoResultadoValidacao)
    {
        if(colecaoResultadoValidacao.Errors.Count > 0)
        {
            var erros = colecaoResultadoValidacao.Errors.Select(e => e.ErrorMessage).ToList();
            foreach (var error in erros)
                AddError(error);
        }

        return CustomResponse(colecaoResultadoValidacao.Data!);
    }

    protected bool IsOperationValid()
    {
        return !_errors.Any();
    }

    protected void AddError(string erro)
    {
        _errors.Add(erro);
    }

    protected void ClearErros()
    {
        _errors.Clear();
    }

}
