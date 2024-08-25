using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITypeRepository
    {
        Task<Int64?> AddAsync(TypeEntity type);

        Task<TypeEntity?> GetByIdAsync(Int64 id);

        Task<TypeEntity?> GetByOriginAsync(string origin);

        Task<IEnumerable<TypeEntity>> GetAllAsync();
    }
}