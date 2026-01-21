using AutoMapper;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Infra.Data;

namespace LZSPatrimonio.Infra.Repositorios;

public class UnidadeAdministrativaRepository : BaseRepository<UnidadeAdministrativa>, IUnidadeAdministrativaRepository
{
    private readonly AppDbContext _context;
    public UnidadeAdministrativaRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }
    IUnitOfWork UnitOfWork => _context;
}
