namespace ElectroParts.Services.DTOs.Manufacturer.Request
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;
    public class AddManufacturerRequestData
    {
        [Required(ErrorMessage = "Полето „Име“ е задължително.")]
        [StringLength(
            EntityValidation.Manufacturer.NameMaxLength,
            MinimumLength = EntityValidation.Manufacturer.NameMinLength,
            ErrorMessage = "Името трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; } = null!;

        [StringLength( EntityValidation.Manufacturer.AddressMaxLength,
            ErrorMessage = "Адресът не може да надвишава {1} символа.")]
        public string? Address { get; set; }

        [StringLength(EntityValidation.Manufacturer.UrlMaxLength,
            ErrorMessage = "Уебсайтът не може да надвишава {1} символа.")]
        [Url(ErrorMessage = "Въведи валиден адрес на уебсайт.")]
        public string? Url { get; set; }
    }
}

