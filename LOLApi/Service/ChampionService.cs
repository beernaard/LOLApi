using LOLApi.Data;
using LOLApi.Interface;
using LOLApi.Model;
using LOLApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace LOLApi.Service
{
    public class ChampionService:IChampionService
    {
        private readonly ApplicationDbContext _context;

        public ChampionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ChampionExists(int id)
        {
            try
            {
                var IfChampExists = await _context.Champions.AnyAsync(x => x.Id == id);
                return IfChampExists;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Champion>> GetListOfChampionBasedOnListOfId(List<int> listOfId)
        {
            try
            {
                var listOfModel = _context.Champions.Where(x => listOfId.Contains(x.Id));
                return await listOfModel.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> GetListOfId(List<ListOfIdModel> model)
        {
            try
            {
                var listOfId = model.Select(x => x.id).ToList();
                return listOfId;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
