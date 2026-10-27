namespace ElectroParts.Services.DTOs.Device.Response
{
    public class GetDeviceDetailsResponseData:GetDevicesResponseData
    {
       
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<PartReferenceResponseData> Parts { get; set; } = [];

        public int DeviceTypeId { get; set; }
    }
}

