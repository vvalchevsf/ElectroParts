namespace ElectroParts.Services.DeviceType
{
    using ElectroParts.Data;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.DeviceType.Response;
    using Microsoft.EntityFrameworkCore;

    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly ElectroPartsDbContext dbContext;

        public DeviceTypeService(ElectroPartsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetDeviceTypesResponseData>> GetAllAsync()
        {
            return await this.dbContext.DeviceTypes
                .OrderBy(dt => dt.Id)
                .Select(dt => new GetDeviceTypesResponseData
                {
                    Id = dt.Id,
                    Name = dt.Name
                })
                .ToArrayAsync();
        }
    }
}
