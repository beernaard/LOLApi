using LOLApi.Model;
using LOLApi.ViewModel;

namespace LOLApi.Mapper
{
    public class ChampionMapper
    {
        public static Champion ChampionVmToClass(CreateChampionViewModel vm)
        {
            return new Champion
            {
                ChampionName = vm.ChampionName,
                championTitle = vm.championTitle,
                championImage = vm.championImage,
                championDescription = vm.championDescription,
                PositionId = vm.PositionId,
                RegionId = vm.RegionId,
                AdaptiveId = vm.AdaptiveId,
                ClassId = vm.ClassId,
                RangeId = vm.RangeId,
            };
        }
    }
}
