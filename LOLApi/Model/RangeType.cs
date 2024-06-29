using System.ComponentModel.DataAnnotations;

namespace LOLApi.Model
{
    public class RangeType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameType { get; set; } = string.Empty;
        public virtual ICollection<Champion> Champions { get; set; }
    }
}
