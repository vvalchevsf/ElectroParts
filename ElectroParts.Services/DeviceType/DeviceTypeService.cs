namespace ElectroParts.Services.DeviceType
{
    using ElectroParts.Data;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.DeviceType.Request;
    using ElectroParts.Services.DTOs.DeviceType.Response;
    using Microsoft.EntityFrameworkCore;
    using ElectroParts.Data.Models;    

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

        public async Task<bool> AddAsync(AddDeviceTypeRequestData request)
        {
            var name = request.Name.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            var exists = await this.dbContext.DeviceTypes
                .AnyAsync(dt => dt.Name == name);

            if (exists)
            {
                return false;
            }

            var deviceType = new DeviceType
            {
                Name = name
            };

            await this.dbContext.DeviceTypes.AddAsync(deviceType);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    }
}
