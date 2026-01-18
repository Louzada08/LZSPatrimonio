using FluentValidation.Results;

namespace LZSPatrimonio.Dominio.Validacao;

public class ColecaoResultadoValidacao : ValidationResult
{
    public object? Data { get; set; }
}
