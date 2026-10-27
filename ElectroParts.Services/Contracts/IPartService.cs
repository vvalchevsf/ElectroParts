namespace ElectroParts.Services.Contracts
{
    using ElectroParts.Services.DTOs.Part.Request;
    using ElectroParts.Services.DTOs.Part.Response;

    public interface IPartService
    {
        Task<IEnumerable<GetPartsResponseData>> GetAllAsync(
            GetPartsRequestData requestData);

        Task<GetPartDetailsResponseData?> GetDetailsAsync(
            GetPartDetailsRequestData requestData);

        Task AddAsync(AddPartRequestData requestData, string? userId);
    }
}
