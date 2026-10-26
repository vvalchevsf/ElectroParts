namespace ElectroParts.ViewModels.Part
{
    public class PartListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string PartTypeName { get; set; } = null!;

        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; } = null!;

        public string? ShortDescription { get; set; }
    }
}