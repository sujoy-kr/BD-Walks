using BDWalks.API.Data;
using BDWalks.API.Interfaces;
using BDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class SQLWalkRepository : IWalksRepository
    {
        private readonly BDWalksDbContext context;

        public SQLWalkRepository(BDWalksDbContext context)
        {
            this.context = context;
        }

        public async Task<Walk> CreateAsync(Walk walkModel)
        {
            await context.Walks.AddAsync(walkModel);
            await context.SaveChangesAsync();

            return walkModel;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            Walk? walkModel = context.Walks.FirstOrDefault(r => r.Id == id);
            if (walkModel == null)
            {
                return null;
            }

            context.Walks.Remove(walkModel);
            await context.SaveChangesAsync();

            return walkModel;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNo = 1, int pageSize = 1000)
        {
            var walkModels = context.Walks
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walkModels = walkModels.Where(w => w.Name.Contains(filterQuery));
                }
            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walkModels = isAscending ? walkModels.OrderBy(w => w.Name) : walkModels.OrderByDescending(w => w.Name);
                }

                if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walkModels = isAscending ? walkModels.OrderBy(w => w.LengthInKm) : walkModels.OrderByDescending(w => w.LengthInKm);
                }
            }

            int skipable = (pageNo - 1) * pageSize;

            return await walkModels.Skip(skipable).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            Walk? walkModel = await context.Walks
                .Include(w => w.Region)
                .Include(w => w.Difficulty)
                .FirstOrDefaultAsync(w => w.Id == id);

            return walkModel;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walkModel)
        {
            Walk? existingModel = await context.Walks.FirstOrDefaultAsync(r => r.Id == id);
            if (existingModel == null)
            {
                return null;
            }

            existingModel.Name = walkModel.Name;
            existingModel.Description = walkModel.Description;
            existingModel.LengthInKm = walkModel.LengthInKm;
            existingModel.WalkImageUrl = walkModel.WalkImageUrl;
            existingModel.DifficultyId = walkModel.DifficultyId;
            existingModel.RegionId = walkModel.RegionId;

            await context.SaveChangesAsync();

            return existingModel;
        }
    }
}
