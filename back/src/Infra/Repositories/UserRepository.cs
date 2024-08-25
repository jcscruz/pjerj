using Domain.Entities;
using Domain.Repositories;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByIdAsync(Int64 id)
        {
            return await _context.Users.AsNoTracking().Include(p => p.Type).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(string? origin)
        {
            var query = _context.Users.AsNoTracking();
            if (!string.IsNullOrEmpty(origin))
            {
                query = query.Where(p => p.Type!.Origin == origin);
            }
            return await query.Include(p => p.Type).ToListAsync();
        }

        public async Task<Int64?> AddAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateAsync(UserEntity user)
        {
            _context.Users.Attach(user);

            if (user.Name != null)
            {
                _context.Entry(user).Property(u => u.Name).IsModified = true;
            }

            if (user.Registration != null)
            {
                _context.Entry(user).Property(u => u.Registration).IsModified = true;
            }

            if (user.DateOfBirth.HasValue)
            {
                _context.Entry(user).Property(u => u.DateOfBirth).IsModified = true;
            }

            if (user.EmailAddress != null)
            {
                _context.Entry(user).Property(u => u.EmailAddress).IsModified = true;
            }

            if (user.TypeId.HasValue)
            {
                _context.Entry(user).Property(u => u.TypeId).IsModified = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int64 id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}