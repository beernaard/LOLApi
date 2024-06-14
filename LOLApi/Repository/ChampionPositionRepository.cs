using LOLApi.Data;
using LOLApi.DTO;
using LOLApi.Interface;
using LOLApi.Model;
using Microsoft.EntityFrameworkCore;

namespace LOLApi.Repository
{
    public class ChampionPositionRepository:GeneralRepository<ChampionPosition>, IChampionPosition
    {
        private readonly ApplicationDbContext _context;

        public ChampionPositionRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PositionName>> GetAllChampionPosition()
        {
            var response = _context.ChampionsPositions
                .Select(x => new PositionName
                {
                    positionName = x.PositionName
                });

            return await response.ToListAsync();
        }

        public async Task<PositionName> GetChampionPosition(int id)
        {
            var response = _context.ChampionsPositions.Where(x => x.Id == id)
            .Select(x => new PositionName
            {
                positionName = x.PositionName
            });
            return await response.FirstOrDefaultAsync();
        }

        public async Task<bool> IfPositionExists(int id)
        {
            var response = await _context.ChampionsPositions.AnyAsync(x=>x.Id==id);
            return response;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateData(ChampionPosition championPosition)
        {
            _context.ChampionsPositions.Update(championPosition);
        }
    }
}
