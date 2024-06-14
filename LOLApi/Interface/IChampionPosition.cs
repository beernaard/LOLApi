using LOLApi.DTO;
using LOLApi.Model;

namespace LOLApi.Interface
{
    public interface IChampionPosition:IUoF<ChampionPosition>
    {
        void UpdateData(ChampionPosition championPosition);
        Task<bool> IfPositionExists(int id);
        Task<IEnumerable<PositionName>> GetAllChampionPosition();
        Task<PositionName> GetChampionPosition(int id);
        Task Save();
    }
}
