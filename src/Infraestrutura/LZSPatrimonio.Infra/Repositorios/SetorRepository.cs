using AutoMapper;
using LZSPatrimonio.Dominio.Entities;
using LZSPatrimonio.Dominio.Interfaces.Repositorios;
using LZSPatrimonio.Infra.Data;

namespace LZSPatrimonio.Infra.Repositorios;

public class SetorRepository : BaseRepository<Setor>, ISetorRepository
{
    private readonly AppDbContext _context;
    public SetorRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }
    IUnitOfWork UnitOfWork => _context;
}
