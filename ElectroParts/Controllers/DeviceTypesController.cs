namespace ElectroParts.Controllers
{
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.DeviceType.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DeviceTypesController : Controller
    {
        private readonly IDeviceTypeService deviceTypeService;

        public DeviceTypesController(IDeviceTypeService deviceTypeService)
        {
            this.deviceTypeService = deviceTypeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDeviceTypeRequestData request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(request);
            }

            var added = await this.deviceTypeService.AddAsync(request);

            if (!added)
            {
                this.ModelState.AddModelError(
                    nameof(request.Name),
                    "Вече съществува тип устройство с това име.");

                return this.View(request);
            }

            return this.RedirectToAction("Create", "Devices");
        }
    }
}

