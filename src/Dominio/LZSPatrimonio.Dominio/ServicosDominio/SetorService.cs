using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Servicos;

namespace LZSPatrimonio.Dominio.ServicosDominio
{
    public class SetorService : ISetorService
    {
        public Task<Setor> Create(Setor category)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Setor category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Setor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Setor> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<Unidade> Update(Unidade category)
        {
            throw new NotImplementedException();
        }
    }
}
