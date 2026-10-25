
using System.ComponentModel.DataAnnotations;
using  ElectroParts.Common.Constants;

namespace ElectroParts.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityValidation.Manufacturer.NameMaxLength)]
        public string Name { get; set; } = null!;

        [StringLength(EntityValidation.Manufacturer.AddressMaxLength)]
        public string? Address { get; set; }

        [StringLength(EntityValidation.Manufacturer.UrlMaxLength)]
        [Url]
        public string? Url { get; set; }
    }
}
