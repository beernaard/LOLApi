using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class ChampionPosition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PositionName { get; set; } = string.Empty;
        public virtual ICollection<Champion> Champions { get; set; }
    }
}
