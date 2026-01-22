using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LZSPatrimonio.Dominio.ServicosDominio
{
    public class UnidadeAdministrativaService : IUnidadeAdministrativaService
    {
        private readonly IUnidadeAdministrativaRepository _repository;
        public UnidadeAdministrativaService(IUnidadeAdministrativaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UnidadeAdministrativa>> GetAll()
        {
            var resposta = await _repository.QueryableFor().ToListAsync();
            return resposta;
        }

        public async Task<UnidadeAdministrativa> GetById(Guid? id)
        {
            var resposta = await _repository.QueryableFor(p => p.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (resposta == null) throw new Exception("Category not found");

            return resposta;
        }

        public async Task<UnidadeAdministrativa> Create(UnidadeAdministrativa unAdmin)
        {
            var ret = _repository.Add(unAdmin);
            await _repository.UnitOfWork.CommitAsync();

            return ret;
        }

        public Task<UnidadeAdministrativa> Update(UnidadeAdministrativa category)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UnidadeAdministrativa category)
        {
            throw new NotImplementedException();
        }

    }
}
