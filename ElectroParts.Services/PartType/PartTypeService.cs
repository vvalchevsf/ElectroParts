namespace ElectroParts.Services.PartType
{
    using ElectroParts.Data;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.PartType.Request;
    using ElectroParts.Services.DTOs.PartType.Response;
    using Microsoft.EntityFrameworkCore;
    using ElectroParts.Data.Models;

    public class PartTypeService : IPartTypeService
    {
        private readonly ElectroPartsDbContext dbContext;

        public PartTypeService(ElectroPartsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetPartTypesResponseData>> GetAllAsync()
        {
            return await this.dbContext.PartTypes
                .OrderBy(pt => pt.Id)
                .Select(pt => new GetPartTypesResponseData
                {
                    Id = pt.Id,
                    Name = pt.Name
                })
                .ToArrayAsync();
        }
    

         public async Task<bool> AddAsync(AddPartTypeRequestData request)
        {
            var name = request.Name.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            var exists = await this.dbContext.PartTypes
                .AnyAsync(pt => pt.Name == name);

            if (exists)
            {
                return false;
            }

            var partType = new PartType
            {
                Name = name
            };

            await this.dbContext.PartTypes.AddAsync(partType);
            await this.dbContext.SaveChangesAsync();

            return true;
        }
    } 
}

