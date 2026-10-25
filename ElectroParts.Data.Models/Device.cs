
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElectroParts.Common.Constants;

namespace ElectroParts.Data.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DeviceTypeId { get; set; }

        [ForeignKey(nameof(DeviceTypeId))]
        public virtual DeviceType DeviceType { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.Device.NameMaxLength)]
        public string Name { get; set; } = null!;

        [StringLength(EntityValidation.Device.ModelMaxLength)]
        public string? Model { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [StringLength(EntityValidation.Device.DescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string? CreatedByUserId { get; set; }
    }
}
