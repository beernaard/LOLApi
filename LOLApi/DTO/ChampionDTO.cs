namespace LOLApi.DTO
{
    public class BasicChampionInfo
    {
        public string ChampionName { get; set; } = string.Empty;
        public string championTitle { get; set; } = string.Empty;
    }

    public class CompleteDetailOfChampion
    {
        public string ChampionName { get; set; } = string.Empty;
        public string championTitle { get; set; } = string.Empty;
        public string championImage { get; set; } = string.Empty;
        public string championDescription { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;
        public string AdaptiveName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string RangeName { get; set; } = string.Empty;
    }
}
