namespace ElectroParts.Services.DTOs.Device.Request
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;

    public class AddDeviceRequestData
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(
            EntityValidation.Device.NameMaxLength,
            MinimumLength = 2,
            ErrorMessage = "Името трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; } = null!;

        [StringLength(
            EntityValidation.Device.ModelMaxLength,
            ErrorMessage = "Моделът не може да надвишава {1} символа.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Избери тип на устройството.")]
        public int DeviceTypeId { get; set; }

        [Required(ErrorMessage = "Избери производител.")]
        public int ManufacturerId { get; set; }

        [StringLength(
            EntityValidation.Device.DescriptionMaxLength,
            ErrorMessage = "Описанието не може да надвишава {1} символа.")]
        public string? Description { get; set; }
    }
}

