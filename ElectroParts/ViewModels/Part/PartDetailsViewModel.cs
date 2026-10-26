namespace ElectroParts.ViewModels.Part
{
    using ElectroParts.ViewModels.Device;

    public class PartDetailsViewModel : PartListViewModel
    {
        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<DeviceReferenceViewModel> Devices { get; set; } = [];
    }
}
