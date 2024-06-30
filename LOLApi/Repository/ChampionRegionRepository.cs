using LOLApi.Data;
using LOLApi.Model;

namespace LOLApi.Repository
{
    public class ChampionRegionRepository:GeneralRepository<ChampionRegion>
    {
        private readonly ApplicationDbContext _context;

        public ChampionRegionRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
