namespace ElectroParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;
    public class PartType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityValidation.PartType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}

