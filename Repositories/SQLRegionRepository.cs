using BDWalks.API.Data;
using BDWalks.API.Interfaces;
using BDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly BDWalksDbContext context;

        public SQLRegionRepository(BDWalksDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await context.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region> CreateAsync(Region regionModel)
        {
            await context.Regions.AddAsync(regionModel);
            await context.SaveChangesAsync();

            return regionModel;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region regionModel)
        {
            Region? existingModel = await context.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingModel == null)
            {
                return null;
            }

            existingModel.Name = regionModel.Name;
            existingModel.Code = regionModel.Code;
            existingModel.RegionImageUrl = regionModel.RegionImageUrl;

            await context.SaveChangesAsync();

            return existingModel;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            Region? regionModel = context.Regions.FirstOrDefault(r => r.Id == id);
            if (regionModel == null)
            {
                return null;
            }

            context.Regions.Remove(regionModel);
            await context.SaveChangesAsync();

            return regionModel;
        }
    }
}
