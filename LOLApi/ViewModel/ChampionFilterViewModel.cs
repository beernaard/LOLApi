using System.ComponentModel.DataAnnotations;

namespace LOLApi.ViewModel
{
    public class ChampionFilterViewModel
    {
        public string ChampionName { get; set; } = string.Empty;
        public string championTitle { get; set; } = string.Empty;
        public int? PositionId { get; set; }
        public int? RegionId { get; set; }
        public int? AdaptiveId { get; set; }
        public int? ClassId { get; set; }
        public int? RangeId { get; set; }
    }
}
