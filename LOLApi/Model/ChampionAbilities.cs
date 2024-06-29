using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class ChampionAbilities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AbilityName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int championId { get; set; }
        [ForeignKey("championId")]
        public virtual Champion Champion { get; set; } = new();
    }
}
