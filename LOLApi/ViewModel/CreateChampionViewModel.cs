namespace LOLApi.ViewModel
{
    public class CreateChampionViewModel
    {
        public string ChampionName { get; set; } = string.Empty;
        public string championTitle { get; set; } = string.Empty;
        public string championImage { get; set; } = string.Empty;
        public string championDescription { get; set; } = string.Empty;
        public int PositionId { get; set; }
    }
}
