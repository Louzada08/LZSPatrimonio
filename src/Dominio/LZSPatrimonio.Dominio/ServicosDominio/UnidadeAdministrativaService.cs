using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Dominio.Interfaces.Servicos;
using Microsoft.EntityFrameworkCore;

namespace LZSPatrimonio.Dominio.ServicosDominio
{
    public class UnidadeAdministrativaService : IUnidadeAdministrativaService
    {
        private readonly IUnidadeAdministrativaRepository _repository;

        public async Task<UnidadeAdministrativa> Create(UnidadeAdministrativa unAdmin)
        {
            var ret = _repository.Add(unAdmin);
            await _repository.UnitOfWork.CommitAsync();

            return ret;
        }

        public Task Delete(UnidadeAdministrativa category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UnidadeAdministrativa>> GetAll()
        {
            var response = await _repository.QueryableFor().ToListAsync();
            return response;
        }

        public Task<UnidadeAdministrativa> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<UnidadeAdministrativa> Update(UnidadeAdministrativa category)
        {
            throw new NotImplementedException();
        }
    }
}
