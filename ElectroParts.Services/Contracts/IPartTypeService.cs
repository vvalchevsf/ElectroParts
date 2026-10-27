namespace ElectroParts.Services.Contracts
{
    using ElectroParts.Services.DTOs.PartType.Request;
    using ElectroParts.Services.DTOs.PartType.Response;

    public interface IPartTypeService
    {
        Task<IEnumerable<GetPartTypesResponseData>> GetAllAsync();

        Task<bool> AddAsync(AddPartTypeRequestData request);
    }
}

