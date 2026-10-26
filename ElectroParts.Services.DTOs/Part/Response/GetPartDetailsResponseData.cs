namespace ElectroParts.Services.DTOs.Part.Response
{
    using ElectroParts.Services.DTOs.Device.Response;

    public class GetPartDetailsResponseData : GetPartsResponseData
    {
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<DeviceReferenceResponseData> Devices { get; set; } = [];
    }
}
