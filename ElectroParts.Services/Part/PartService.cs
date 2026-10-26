namespace ElectroParts.Services.Part
{
    using ElectroParts.Data;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Part.Request;
    using ElectroParts.Services.DTOs.Part.Response;
    using ElectroParts.Services.DTOs.Device.Response;
    using Microsoft.EntityFrameworkCore;

    public class PartService : IPartService
    {
        private readonly ElectroPartsDbContext dbContext;

        public PartService(ElectroPartsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetPartsResponseData>> GetAllAsync(
            GetPartsRequestData requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            if (requestData.SkipEntries < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(requestData.SkipEntries));
            }

            if (requestData.TakeEntries <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(requestData.TakeEntries));
            }

            return await this.dbContext.Parts
                .OrderBy(p => p.Id)
                .Skip(requestData.SkipEntries)
                .Take(requestData.TakeEntries)
                .Select(p => new GetPartsResponseData
                {
                    Id = p.Id,
                    Name = p.Name,
                    PartTypeName = p.PartType.Name,
                    ManufacturerId = p.ManufacturerId,
                    ManufacturerName = p.Manufacturer.Name,
                    ShortDescription = p.ShortDescription
                })
                .ToArrayAsync();
        }

        public async Task<GetPartDetailsResponseData?> GetDetailsAsync(
            GetPartDetailsRequestData requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            if (requestData.Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(requestData.Id));
            }

            return await this.dbContext.Parts
                .Where(p => p.Id == requestData.Id)
                .Select(p => new GetPartDetailsResponseData
                {
                    Id = p.Id,
                    Name = p.Name,
                    PartTypeName = p.PartType.Name,
                    ManufacturerId = p.ManufacturerId,
                    ManufacturerName = p.Manufacturer.Name,
                    ShortDescription = p.ShortDescription,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn,
                    Devices = this.dbContext.DeviceParts
                        .Where(dp => dp.PartId == p.Id)
                        .Select(dp => new DeviceReferenceResponseData
                        {
                            Id = dp.DeviceId,
                            Name = dp.Device.Name
                        })
                        .ToArray()
                })
                .FirstOrDefaultAsync();
        }
    }
}
