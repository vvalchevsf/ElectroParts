namespace ElectroParts.Services.DTOs.Manufacturer.Request
{
    using ElectroParts.Common;

    public class GetManufacturersRequestData
    {
        public int SkipEntries { get; set; }
            = ApplicationConstants.DefaultSkipEntries;

        public int TakeEntries { get; set; }
            = ApplicationConstants.DefaultTakeEntries;
    }
}