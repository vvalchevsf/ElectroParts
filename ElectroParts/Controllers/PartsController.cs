namespace ElectroParts.Controllers
{
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Manufacturer.Request;
    using ElectroParts.Services.DTOs.Part.Request;
    using ElectroParts.ViewModels.Device;
    using ElectroParts.ViewModels.Part;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PartsController : Controller
    {
        private readonly IPartService partService;
        private readonly IManufacturerService manufacturerService;
        private readonly IPartTypeService partTypeService;

        public PartsController( IPartService partService,
                                IManufacturerService manufacturerService,
                               IPartTypeService partTypeService)
        {
            this.partService = partService;
            this.manufacturerService = manufacturerService;
            this.partTypeService = partTypeService;
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

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Create()
        {
            await LoadCreateViewDataAsync();
            return View();
        }

        private async Task LoadCreateViewDataAsync()
        {
            var manufacturers = await this.manufacturerService.GetAllAsync(
                new GetManufacturersRequestData
                {
                    SkipEntries = 0,
                    TakeEntries = 1000
                });

            var partTypes = await this.partTypeService.GetAllAsync();

            ViewBag.Manufacturers = manufacturers;
            ViewBag.PartTypes = partTypes;
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPartRequestData requestData)
        {
            if (!ModelState.IsValid)
            {
                await LoadCreateViewDataAsync();
                return View(requestData);
            }

            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            await this.partService.AddAsync(requestData, userId);

            return RedirectToAction(nameof(Index));
        }




    }
}
