namespace ElectroParts.Services.Contracts
{
    using ElectroParts.Services.DTOs.Manufacturer.Request;
    using ElectroParts.Services.DTOs.Manufacturer.Response;

    public interface IManufacturerService
    {
        Task<IEnumerable<GetManufacturersResponseData>> GetAllAsync(
            GetManufacturersRequestData requestData);

        Task AddAsync(AddManufacturerRequestData requestData);
    }
}
