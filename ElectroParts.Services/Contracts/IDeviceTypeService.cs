namespace ElectroParts.Services.Contracts
{
    using ElectroParts.Services.DTOs.DeviceType.Request;
    using ElectroParts.Services.DTOs.DeviceType.Response;

    public interface IDeviceTypeService
    {
        Task<IEnumerable<GetDeviceTypesResponseData>> GetAllAsync();

        Task<bool> AddAsync(AddDeviceTypeRequestData request);
    }
}

