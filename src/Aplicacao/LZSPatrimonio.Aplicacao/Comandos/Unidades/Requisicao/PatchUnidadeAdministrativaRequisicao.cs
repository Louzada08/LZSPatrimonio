using LZSPatrimonio.Dominio.Mediator;
using Microsoft.AspNetCore.JsonPatch;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao
{
    public class PatchUnidadeAdministrativaRequisicao : Command
    {
        public PatchUnidadeAdministrativaRequisicao() { }
        public PatchUnidadeAdministrativaRequisicao(Guid id, JsonPatchDocument<PatchUnidadeAdministrativaRequisicao>
            patchUnidAdminRequest)
        {
            PatchUnidAdminRequest = patchUnidAdminRequest;
            Id = id;
        }
        public JsonPatchDocument<PatchUnidadeAdministrativaRequisicao> PatchUnidAdminRequest { get; set; }
        public override bool IsValid()
        {
            return true;
        }

        public Guid Id { get; set; }
        public short CodigoInterno { get; set; }
        public string Nome { get; set; }
    }
}
