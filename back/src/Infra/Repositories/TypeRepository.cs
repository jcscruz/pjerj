using Domain.Entities;
using Domain.Repositories;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public sealed class TypeRepository : ITypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Int64?> AddAsync(TypeEntity type)
        {
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();
            return type.Id;
        }

        public async Task<IEnumerable<TypeEntity>> GetAllAsync()
        {
            return await _context.Types.AsNoTracking().ToListAsync();
        }

        public async Task<TypeEntity?> GetByIdAsync(Int64 id)
        {
            return await _context.Types.FindAsync(id);
        }

        public async Task<TypeEntity?> GetByOriginAsync(string origin)
        {
            return await _context.Types.AsNoTracking().Where(p => p.Origin == origin).FirstOrDefaultAsync();
        }
    }
}