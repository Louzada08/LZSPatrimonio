using LZSPatrimonio.Dominio.Mediator;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao;

public class DeleteUnidadeAdministrativaRequisicao : Command
{
    public DeleteUnidadeAdministrativaRequisicao(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }

    public override bool IsValid()
    {
        return Guid.Empty != Id;
    }
}
