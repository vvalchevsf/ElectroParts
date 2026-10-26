namespace ElectroParts.Services.DTOs.Part.Response
{
    public class GetPartsResponseData
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string PartTypeName { get; set; } = null!;

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; } = null!;

        public string? ShortDescription { get; set; }
    }
}
