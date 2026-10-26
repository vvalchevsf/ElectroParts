namespace ElectroParts.Controllers
{
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Part.Request;
    using ElectroParts.ViewModels.Device;
    using ElectroParts.ViewModels.Part;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private readonly IPartService partService;

        public PartsController(IPartService partService)
        {
            this.partService = partService;
        }

        public async Task<IActionResult> Index()
        {
            var requestData = new GetPartsRequestData
            {
                SkipEntries = 0,
                TakeEntries = 10
            };

            var parts = await this.partService.GetAllAsync(requestData);

            var model = parts.Select(p => new PartListViewModel
            {
                Id = p.Id,
                Name = p.Name,
                PartTypeName = p.PartTypeName,
                ManufacturerId = p.ManufacturerId,
                ManufacturerName = p.ManufacturerName,
                ShortDescription = p.ShortDescription
            });

            return this.View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var requestData = new GetPartDetailsRequestData
            {
                Id = id
            };

            var part = await this.partService.GetDetailsAsync(requestData);

            if (part == null)
            {
                return this.NotFound();
            }

            var model = new PartDetailsViewModel
            {
                Id = part.Id,
                Name = part.Name,
                PartTypeName = part.PartTypeName,
                ManufacturerId = part.ManufacturerId,
                ManufacturerName = part.ManufacturerName,
                ShortDescription = part.ShortDescription,
                Description = part.Description,
                CreatedOn = part.CreatedOn,
                Devices = part.Devices.Select(d => new DeviceReferenceViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
            };

            return this.View(model);
        }


    }
}
