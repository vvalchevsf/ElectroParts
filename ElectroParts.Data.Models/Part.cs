
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElectroParts.Common.Constants;

namespace ElectroParts.Data.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PartTypeId { get; set; }

        [ForeignKey(nameof(PartTypeId))]
        public virtual PartType PartType { get; set; } = null!;

        [Required]
        [StringLength(EntityValidation.Part.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [StringLength(EntityValidation.Part.ShortDescriptionMaxLength)]
        public string? ShortDescription { get; set; }

        [StringLength(EntityValidation.Part.DescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string? CreatedByUserId { get; set; }
    }
}
