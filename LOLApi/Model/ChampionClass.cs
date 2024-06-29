using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class ChampionClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; } = string.Empty;

        public virtual ICollection<Champion> Champions { get; set; }
    }
}
