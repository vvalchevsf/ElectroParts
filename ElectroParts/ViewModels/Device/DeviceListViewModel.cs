namespace ElectroParts.ViewModels.Device
{
    public class DeviceListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Model { get; set; }

        public string DeviceTypeName { get; set; } = null!;

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; } = null!;
    }
}

