
namespace ElectroParts.Services.Contracts
{
    using ElectroParts.Services.DTOs.Device.Request;
    using ElectroParts.Services.DTOs.Device.Response;

    public interface IDeviceService
    {
        Task<IEnumerable<GetDevicesResponseData>> GetAllAsync(
            GetDevicesRequestData requestData);
    }
}
