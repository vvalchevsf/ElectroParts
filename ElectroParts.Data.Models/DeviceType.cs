
using System.ComponentModel.DataAnnotations;
using ElectroParts.Common.Constants;

namespace ElectroParts.Data.Models
{
    public class DeviceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityValidation.DeviceType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
