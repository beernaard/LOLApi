using LOLApi.Data;
using LOLApi.DTO;
using LOLApi.Interface;
using LOLApi.Model;
using LOLApi.ViewModel;
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
                .Include(c => c.adaptiveType)
                .Include(c => c.championClass)
                .Include(c => c.championRegion)
                .Include(c => c.rangeType)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                    RegionName = a.championRegion.RegionName,
                    AdaptiveName  =a.adaptiveType.AdaptiveName,
                    ClassName = a.championClass.ClassName,
                    RangeName = a.rangeType.NameType,
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

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByFilter(ChampionFilterViewModel vm)
        {
            var query = _context.Champions.AsQueryable();

            if (!string.IsNullOrEmpty(vm.ChampionName))
            {
                query = query.Where(x => x.ChampionName.Contains(vm.ChampionName));
            }
            if (!string.IsNullOrEmpty(vm.championTitle))
            {
                query = query.Where(x => x.championTitle.Contains(vm.championTitle));
            }
            if (vm.PositionId.HasValue)
            {
                query = query.Where(x => x.PositionId == vm.PositionId);
            }
            if (vm.RegionId.HasValue)
            {
                query = query.Where(x => x.RegionId == vm.RegionId);
            }
            if (vm.AdaptiveId.HasValue)
            {
                query = query.Where(x => x.AdaptiveId == vm.AdaptiveId);
            }
            if (vm.ClassId.HasValue)
            {
                query = query.Where(x => x.ClassId == vm.ClassId);
            }
            if (vm.RangeId.HasValue)
            {
                query = query.Where(x => x.RangeId == vm.RangeId);
            }
            var result = query
                .Include(z => z.championPosition)
                .Include(c => c.adaptiveType)
                .Include(c => c.championClass)
                .Include(c => c.championRegion)
                .Include(c => c.rangeType)
                .Select(a=> new CompleteDetailOfChampion
            {
                ChampionName = a.ChampionName,
                championTitle = a.championTitle,
                championImage = a.championImage,
                championDescription = a.championDescription,
                PositionName = a.championPosition.PositionName,
                RegionName = a.championRegion.RegionName,
                AdaptiveName = a.adaptiveType.AdaptiveName,
                ClassName = a.championClass.ClassName,
                RangeName = a.rangeType.NameType,
            });
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByName(string name)
        {
            var response = _context.Champions
                .Where(x => x.ChampionName.Contains(name))
                .Include(z=>z.championPosition)
                .Include(c => c.adaptiveType)
                .Include(c => c.championClass)
                .Include(c => c.championRegion)
                .Include(c => c.rangeType)
                .Select(a=>new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                    RegionName = a.championRegion.RegionName,
                    AdaptiveName = a.adaptiveType.AdaptiveName,
                    ClassName = a.championClass.ClassName,
                    RangeName = a.rangeType.NameType,
                });
            return await response.ToListAsync();
        }

        public async Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByPosition(int id)
        {
            var response =  _context.Champions
                .AsNoTracking()
                .Include(a => a.championPosition)
                .Include(c => c.adaptiveType)
                .Include(c => c.championClass)
                .Include(c => c.championRegion)
                .Include(c => c.rangeType)
                .Where(x => x.PositionId == id)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                    RegionName = a.championRegion.RegionName,
                    AdaptiveName = a.adaptiveType.AdaptiveName,
                    ClassName = a.championClass.ClassName,
                    RangeName = a.rangeType.NameType,
                });

            return await response.ToListAsync();
        }

        public async Task<CompleteDetailOfChampion> GetOneCompleteDetails(int id)
        {
            var response = _context.Champions.Where(x => x.Id == id)
                .Include(c => c.championPosition)
                .Include(c => c.adaptiveType)
                .Include(c => c.championClass)
                .Include(c => c.championRegion)
                .Include(c => c.rangeType)
                .Select(a => new CompleteDetailOfChampion
                {
                    ChampionName = a.ChampionName,
                    championTitle = a.championTitle,
                    championImage = a.championImage,
                    championDescription = a.championDescription,
                    PositionName = a.championPosition.PositionName,
                    RegionName = a.championRegion.RegionName,
                    AdaptiveName = a.adaptiveType.AdaptiveName,
                    ClassName = a.championClass.ClassName,
                    RangeName = a.rangeType.NameType,
                });
            return await response.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<CompleteDetailOfChampion>> PaginatedOfFullDetailChampion(int pageNumber, int pageSize)
        {
            var response = _context.Champions
                     .Include(c => c.championPosition)
                     .Include(c => c.adaptiveType)
                     .Include(c => c.championClass)
                     .Include(c => c.championRegion)
                     .Include(c => c.rangeType)
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
                         RegionName = a.championRegion.RegionName,
                         AdaptiveName = a.adaptiveType.AdaptiveName,
                         ClassName = a.championClass.ClassName,
                         RangeName = a.rangeType.NameType,
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
