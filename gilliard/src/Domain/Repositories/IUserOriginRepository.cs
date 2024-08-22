using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserOriginRepository
    {
        Task<UserOriginEntity> GetByIdAsync(int id);

        Task<IEnumerable<UserOriginEntity>> GetAllAsync();

        Task<IEnumerable<UserOriginEntity>> GetFilteredAsync(string filter);

        Task AddAsync(UserOriginEntity user);

        Task UpdateAsync(UserOriginEntity user);

        Task DeleteAsync(int id);
    }
}