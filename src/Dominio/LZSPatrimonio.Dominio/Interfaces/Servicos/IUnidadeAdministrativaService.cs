using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Dominio.Interfaces.Servicos
{
    public interface IUnidadeAdministrativaService
    {
        Task<IEnumerable<UnidadeAdministrativa>> GetAll();
        Task<UnidadeAdministrativa> GetById(Guid? id);
        Task<UnidadeAdministrativa> Create(UnidadeAdministrativa category);
        Task<UnidadeAdministrativa> Update(UnidadeAdministrativa category);
        Task Delete(UnidadeAdministrativa category);
    }
}
