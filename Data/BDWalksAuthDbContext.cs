using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Data
{
    public class BDWalksAuthDbContext : IdentityDbContext
    {
        public BDWalksAuthDbContext(DbContextOptions<BDWalksAuthDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> Roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = "32415cbe-6aac-47f3-8751-5e21ba1287d3",
                    ConcurrencyStamp = "32415cbe-6aac-47f3-8751-5e21ba1287d3",
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                },
                new IdentityRole {
                    Id = "5616c6f9-cb55-43a5-ac47-f9649961d707",
                    ConcurrencyStamp = "5616c6f9-cb55-43a5-ac47-f9649961d707",
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }
            };

            builder.Entity<IdentityRole>().HasData(Roles);
        }
    }
}
