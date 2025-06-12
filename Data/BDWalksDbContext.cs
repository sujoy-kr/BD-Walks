using BDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Data
{
    public class BDWalksDbContext : DbContext
    {
        public BDWalksDbContext(DbContextOptions<BDWalksDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Difficulty> difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id= Guid.Parse("dc672c75-0151-4a2b-94f4-53eae597edf3"),
                    Name= "Easy"
                },
                new Difficulty()
                {
                    Id=  Guid.Parse("445a802b-60f9-4585-8367-11d25dac1958"),
                    Name= "Medium"
                },
                new Difficulty()
                {
                    Id=  Guid.Parse("eb121c76-77cb-47b6-ade0-750133dc2e6b"),
                    Name= "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}
