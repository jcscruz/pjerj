using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(Int64 id);

        Task<IEnumerable<UserEntity>> GetAllAsync(string? origin);

        Task<Int64?> AddAsync(UserEntity user);

        Task UpdateAsync(UserEntity user);

        Task DeleteAsync(Int64 id);
    }
}