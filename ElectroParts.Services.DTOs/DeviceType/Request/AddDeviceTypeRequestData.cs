namespace ElectroParts.Services.DTOs.DeviceType.Request
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;

    public class AddDeviceTypeRequestData
    {
        [Required]
        [StringLength(EntityValidation.DeviceType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}

