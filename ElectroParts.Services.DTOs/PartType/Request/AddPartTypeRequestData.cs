namespace ElectroParts.Services.DTOs.PartType.Request
{
    using System.ComponentModel.DataAnnotations;
    using ElectroParts.Common.Constants;

    public class AddPartTypeRequestData
    {
        [Required]
        [StringLength(EntityValidation.PartType.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}

