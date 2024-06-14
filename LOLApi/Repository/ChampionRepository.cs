using LOLApi.Data;
using LOLApi.DTO;
using LOLApi.Interface;
using LOLApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LOLApi.Repository
{
    public class ChampionRepository:GeneralRepository<Champion>, IChampion
    {
        private readonly ApplicationDbContext _context;

        public ChampionRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetAllCompleteDetails()
        {
            var response = _context.Champions
                .AsNoTracking()
                .Include(c => c.championPosition)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                });
            return await response.ToListAsync();
        }

        public async Task<IEnumerable<BasicChampionInfo>> GetBasicInfoOfAllChampion()
        {
            var response = _context.Champions
                .AsNoTracking()
                .Select(a => new BasicChampionInfo
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                });
            return await response.ToListAsync();
        }

        public async Task<BasicChampionInfo> GetBasicInfoOfOneChampion(int id)
        {
            var response = _context.Champions.Where(x => x.Id == id)
                .Select(a => new BasicChampionInfo
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                });
            return await response.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByName(string name)
        {
            var response = _context.Champions
                .Where(x => x.ChampionName.Contains(name))
                .Include(z=>z.championPosition)
                .Select(a=>new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                });
            return await response.ToListAsync();
        }

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByPosition(int id)
        {
            var response =  _context.Champions
                .AsNoTracking()
                .Include(a => a.championPosition)
                .Where(x => x.PositionId == id)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                });

            return await response.ToListAsync();
        }

        public async Task<CompleteDetailOfChampion> GetOneCompleteDetails(int id)
        {
            var response = _context.Champions.Where(x => x.Id == id)
                .Include(c => c.championPosition)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                });
            return await response.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<CompleteDetailOfChampion>> PaginatedOfFullDetailChampion(int pageNumber, int pageSize)
        {
            var response = _context.Champions
                     .Include(c => c.championPosition)
                     .OrderBy(x => x.Id)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .Select(a => new CompleteDetailOfChampion
                     {
                         ChampionName = a.ChampionName,
                         championTitle = a.championTitle,
                         championImage = a.championImage,
                         championDescription = a.championDescription,
                         PositionName = a.championPosition.PositionName,
                     });
            return await response.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateData(Champion champion)
        {
            _context.Champions.Update(champion);
        }
    }
}
