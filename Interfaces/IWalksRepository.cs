using BDWalks.API.Models.Domain;

namespace BDWalks.API.Interfaces
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNo = 1, int pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walkModel);
        Task<Walk?> UpdateAsync(Guid id, Walk walkModel);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
