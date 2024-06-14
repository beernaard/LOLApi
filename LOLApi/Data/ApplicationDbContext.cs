using LOLApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LOLApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<ChampionPosition> ChampionsPositions { get; set; }
    }
}
