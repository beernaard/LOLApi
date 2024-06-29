using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class AdaptiveType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AdaptiveName { get; set; } = string.Empty;
        public virtual ICollection<Champion> Champions { get; set; }
    }
}
