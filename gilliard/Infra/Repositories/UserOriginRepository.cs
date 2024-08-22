using Domain.Entities;
using Domain.Repositories;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserOriginRepository : IUserOriginRepository
    {
        private readonly ApplicationDbContext _context;

        public UserOriginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserOriginEntity?> GetByIdAsync(int id)
        {
            return await _context.UserOrigin.FindAsync(id);
        }

        public async Task<IEnumerable<UserOriginEntity>> GetAllAsync()
        {
            return await _context.UserOrigin.ToListAsync();
        }

        public async Task<IEnumerable<UserOriginEntity>> GetFilteredAsync(string filter)
        {
            return await _context.UserOrigin
                .Where(u => u.Descricao.Contains(filter) || u.Descricao!.Contains(filter))
                .ToListAsync();
        }

        public async Task AddAsync(UserOriginEntity user)
        {
            await _context.UserOrigin.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserOriginEntity user)
        {
            _context.UserOrigin.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.UserOrigin.FindAsync(id);
            if (user is not null)
            {
                _context.UserOrigin.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}