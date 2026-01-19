using LZSPatrimonio.Dominio.Entities;

namespace LZSPatrimonio.Dominio.Interfaces.Servicos
{
    public interface ISetorService
    {
        Task<IEnumerable<Setor>> GetAll();
        Task<Setor> GetById(Guid? id);
        Task<Setor> Create(Setor category);
        Task<Unidade> Update(Unidade category);
        Task Delete(Setor category);
    }
}
