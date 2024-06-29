namespace LOLApi.Model
{
    public class ChampionRegion
    {
        public int Id { get; set; }
        public string RegionName { get; set; } = string.Empty;
        public virtual ICollection<Champion> Champions { get; set; }
    }
}
