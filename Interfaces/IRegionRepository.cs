using BDWalks.API.Models.Domain;

namespace BDWalks.API.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region regionModel);
        Task<Region?> UpdateAsync(Guid id, Region regionModel);
        Task<Region?> DeleteAsync(Guid id);
    }
}
