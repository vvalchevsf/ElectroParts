
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectroParts.Data.Models
{
    public class DevicePart
    {
        [Required]
        public int DeviceId { get; set; }

        [ForeignKey(nameof(DeviceId))]
        public virtual Device Device { get; set; } = null!;

        [Required]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public virtual Part Part { get; set; } = null!;
    }
}

