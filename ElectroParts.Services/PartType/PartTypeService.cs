namespace ElectroParts.Services.PartType
{
    using ElectroParts.Data;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.PartType.Response;
    using Microsoft.EntityFrameworkCore;

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
    }
}

