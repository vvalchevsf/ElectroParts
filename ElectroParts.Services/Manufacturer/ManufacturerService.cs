namespace ElectroParts.Services.Manufacturer
{
    using ElectroParts.Data;
    using ElectroParts.Data.Models;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Manufacturer.Request;
    using ElectroParts.Services.DTOs.Manufacturer.Response;
    using Microsoft.EntityFrameworkCore;

    public class ManufacturerService : IManufacturerService
    {
        private readonly ElectroPartsDbContext dbContext;

        public ManufacturerService(ElectroPartsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetManufacturersResponseData>> GetAllAsync(
            GetManufacturersRequestData requestData)
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

            return await dbContext.Manufacturers
                .OrderBy(m => m.Id)
                .Skip(requestData.SkipEntries)
                .Take(requestData.TakeEntries)
                .Select(m => new GetManufacturersResponseData
                {
                    Id = m.Id,
                    Name = m.Name,
                    Address = m.Address,
                    Url = m.Url
                })
                .ToArrayAsync();
        }

        public async Task AddAsync(AddManufacturerRequestData requestData)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }

            var manufacturer = new Manufacturer
            {
                Name = requestData.Name,
                Address = requestData.Address,
                Url = requestData.Url
            };

            await dbContext.Manufacturers.AddAsync(manufacturer);
            await dbContext.SaveChangesAsync();
        }
    }
}