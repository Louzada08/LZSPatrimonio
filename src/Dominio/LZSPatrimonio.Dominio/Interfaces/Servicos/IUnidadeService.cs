using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Dominio.Interfaces.Servicos
{
    public interface IUnidadeService
    {
        Task<IEnumerable<Unidade>> GetAll();
        Task<Unidade> GetById(Guid? id);
        Task<Unidade> Create(Unidade category);
        Task<Unidade> Update(Unidade category);
        Task Delete(Unidade category);
    }
}
