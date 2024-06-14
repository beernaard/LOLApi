using LOLApi.Model;
using LOLApi.ViewModel;

namespace LOLApi.Interface
{
    public interface IChampionService
    {
        Task<bool> ChampionExists(int id);
        List<int> GetListOfId(List<ListOfIdModel> model);
        Task<List<Champion>> GetListOfChampionBasedOnListOfId(List<int> listOfId);
    }
}
