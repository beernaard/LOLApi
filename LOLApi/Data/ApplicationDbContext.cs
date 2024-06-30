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
        public DbSet<ChampionAbilities> ChampionsAbilities { get; set; }
        public DbSet<AdaptiveType> AdaptiveTypes { get; set; }
        public DbSet<ChampionClass> ChampionClasses { get; set; }
        public DbSet<ChampionPosition> ChampionsPositions { get; set; }
        public DbSet<ChampionRegion> ChampionsRegion { get; set; }
        public DbSet<RangeType> RangeTypes { get; set; }
    }
}
