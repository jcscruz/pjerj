using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(int id);

        Task<IEnumerable<UserEntity>> GetAllAsync();

        Task<IEnumerable<UserEntity>> GetFilteredAsync(string filter);

        Task AddAsync(UserEntity user);

        Task UpdateAsync(UserEntity user);

        Task DeleteAsync(int id);
    }
}