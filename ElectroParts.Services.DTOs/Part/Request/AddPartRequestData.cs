namespace ElectroParts.Services.DTOs.Part.Request
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;

    public class AddPartRequestData
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength( EntityValidation.Part.NameMaxLength, MinimumLength = 2,
            ErrorMessage = "Името трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Избери тип на частта.")]
        public int PartTypeId { get; set; }

        [Required(ErrorMessage = "Избери производител.")]
        public int ManufacturerId { get; set; }

        [StringLength(
            EntityValidation.Part.ShortDescriptionMaxLength,
            ErrorMessage = "Краткото описание не може да надвишава {1} символа.")]
        public string? ShortDescription { get; set; }

        [StringLength(
            EntityValidation.Part.DescriptionMaxLength,
            ErrorMessage = "Описанието не може да надвишава {1} символа.")]
        public string? Description { get; set; }
    }
}

