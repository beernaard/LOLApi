using LOLApi.DTO;
using LOLApi.Model;
using LOLApi.ViewModel;

namespace LOLApi.Interface
{
    public interface IChampion:IUoF<Champion>
    {
        void UpdateData(Champion champion);
        Task<IEnumerable<CompleteDetailOfChampion>> GetAllCompleteDetails();
        Task<CompleteDetailOfChampion> GetOneCompleteDetails(int id);
        Task<IEnumerable<BasicChampionInfo>> GetBasicInfoOfAllChampion();
        Task<BasicChampionInfo> GetBasicInfoOfOneChampion(int id);
        Task<IEnumerable<CompleteDetailOfChampion>> PaginatedOfFullDetailChampion(int pageNumber, int pageSize);
        Task Save();

        Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByName(string name);
        Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByPosition(int id);
        Task<IEnumerable<CompleteDetailOfChampion>> GetChampionByFilter(ChampionFilterViewModel vm);
    }
}
