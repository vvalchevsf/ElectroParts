
using System.ComponentModel.DataAnnotations;
using ElectroParts.Common.Constants;

namespace ElectroParts.Data.Models
{
    public class PartType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityValidation.PartType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}

