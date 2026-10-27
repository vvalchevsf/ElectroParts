namespace ElectroParts.Services.DTOs.Manufacturer.Response
{
    public class GetManufacturersResponseData
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Url { get; set; }
    }
}
