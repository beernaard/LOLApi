using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class Champion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ChampionName { get; set; } = string.Empty;
        [Required]
        public string championTitle { get; set; } = string.Empty;
        public string championImage { get; set; } = string.Empty;
        public string championDescription { get; set; } = string.Empty;
        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual ChampionPosition? championPosition { get; set; }
    }
}
