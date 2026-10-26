
using ElectroParts.Data;
using ElectroParts.Services.Contracts;
using ElectroParts.Services.DTOs.Device.Request;
using ElectroParts.Services.DTOs.Device.Response;
using Microsoft.EntityFrameworkCore;

namespace ElectroParts.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ElectroPartsDbContext dbContext;

        public DeviceService(ElectroPartsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetDevicesResponseData>> GetAllAsync(
            GetDevicesRequestData requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            if (requestData.SkipEntries < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(requestData.SkipEntries));
            }

            if (requestData.TakeEntries <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(requestData.TakeEntries));
            }

            return await dbContext.Devices
                .OrderBy(d => d.Id)
                .Skip(requestData.SkipEntries)
                .Take(requestData.TakeEntries)
                .Select(d => new GetDevicesResponseData
                {
                    Id = d.Id,
                    Name = d.Name,
                    Model = d.Model,
                    DeviceTypeName = d.DeviceType.Name,
                    ManufacturerId = d.ManufacturerId,
                    ManufacturerName = d.Manufacturer.Name
                })
                .ToArrayAsync();
        }

        public async Task<GetDeviceDetailsResponseData?> GetDetailsAsync(
            GetDeviceDetailsRequestData requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            if (requestData.Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(requestData.Id));
            }

            return await dbContext.Devices
                .Where(d => d.Id == requestData.Id)
                .Select(d => new GetDeviceDetailsResponseData
                {
                    Id = d.Id,
                    Name = d.Name,
                    Model = d.Model,
                    DeviceTypeName = d.DeviceType.Name,
                    ManufacturerId = d.ManufacturerId,
                    ManufacturerName = d.Manufacturer.Name,
                    Description = d.Description,
                    CreatedOn = d.CreatedOn,
                    Parts = dbContext.DeviceParts
                                .Where(dp => dp.DeviceId == d.Id)
                                .Select(dp => new PartReferenceResponseData
                                {
                                    Id = dp.PartId,
                                    Name = dp.Part.Name
                                })
                                .ToArray()
                })
                .FirstOrDefaultAsync();
        }



    }
}

