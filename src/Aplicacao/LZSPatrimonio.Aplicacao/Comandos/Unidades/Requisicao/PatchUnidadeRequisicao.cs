using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Enums;
using LZSPatrimonio.Dominio.Mediator;
using Microsoft.AspNetCore.JsonPatch;

namespace LZSPatrimonio.Aplicacao.Comandos.Unidades.Requisicao
{
    public class PatchUnidadeRequisicao : Command
    {
        public PatchUnidadeRequisicao() { }
        public PatchUnidadeRequisicao(Guid id, JsonPatchDocument<PatchUnidadeRequisicao>
            patchUnidadeRequest)
        {
            PatchUnidadeRequest = patchUnidadeRequest;
            Id = id;
        }
        public JsonPatchDocument<PatchUnidadeRequisicao> PatchUnidadeRequest { get; set; }
        public override bool IsValid()
        {
            return true;
        }

        public Guid Id { get; set; }
        public Guid UnidadeAdminstrativaId { get; set; }
        public UnidadeAdministrativa? UnidadeAdministrativa { get; set; }
        public short CodigoInterno { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public FundoEnum TipoFundo { get; set; }
    }
}
