namespace ElectroParts.ViewModels.Device
{
    using ElectroParts.ViewModels.Part;

    public class DeviceDetailsViewModel : DeviceListViewModel
    {
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<PartReferenceViewModel> Parts { get; set; } = [];
    }
}
