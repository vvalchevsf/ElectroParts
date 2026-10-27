namespace ElectroParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;

    public class DeviceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityValidation.DeviceType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
