namespace ElectroParts.Controllers
{
    using ElectroParts.Common;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Device.Request;
    using ElectroParts.Services.DTOs.Device.Response;
    using ElectroParts.Services.DTOs.Manufacturer.Request;
    using ElectroParts.ViewModels.Device;
    using ElectroParts.ViewModels.Part;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DevicesController : BaseController
    {
        private readonly IDeviceService deviceService;
        private readonly IManufacturerService manufacturerService;
        private readonly IDeviceTypeService deviceTypeService;

        public DevicesController(  IDeviceService deviceService,
                                   IManufacturerService manufacturerService,
                                   IDeviceTypeService deviceTypeService)
        {
            this.deviceService = deviceService;
            this.manufacturerService = manufacturerService;
            this.deviceTypeService = deviceTypeService;
        }


        public async Task<IActionResult> Index()
        {
            var requestData = new GetDevicesRequestData
            {
                SkipEntries = ApplicationConstants.DefaultSkipEntries,
                TakeEntries = ApplicationConstants.DefaultTakeEntries
            };

            var devices = await deviceService.GetAllAsync(requestData);

            var model = devices.Select(d => new DeviceListViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Model = d.Model,
                DeviceTypeName = d.DeviceTypeName,
                ManufacturerId = d.ManufacturerId,
                ManufacturerName = d.ManufacturerName
            }).ToList();

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var requestData = new GetDeviceDetailsRequestData
            {
                Id = id
            };

            var device = await deviceService.GetDetailsAsync(requestData);

            if (device == null)
            {
                return NotFound();
            }

            var model = new DeviceDetailsViewModel
            {
                Id = device.Id,
                Name = device.Name,
                Model = device.Model,
                DeviceTypeName = device.DeviceTypeName,
                ManufacturerId = device.ManufacturerId,
                ManufacturerName = device.ManufacturerName,
                Description = device.Description,
                CreatedOn = device.CreatedOn,
                Parts = device.Parts.Select(p => new PartReferenceViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
            };

            return View(model);
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

            var deviceTypes = await this.deviceTypeService.GetAllAsync();

            ViewBag.Manufacturers = manufacturers;
            ViewBag.DeviceTypes = deviceTypes;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDeviceRequestData requestData)
        {
            if (!ModelState.IsValid)
            {
                await LoadCreateViewDataAsync();
                return View(requestData);
            }

            var userId = User.FindFirst(
                System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            await this.deviceService.AddAsync(requestData, userId);

            return RedirectToAction(nameof(Index));
        }

    }
}


