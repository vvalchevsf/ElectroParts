
namespace ElectroParts.Controllers
{
    using ElectroParts.Common;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Device.Request;
    using ElectroParts.Services.DTOs.Device.Response;
    using ElectroParts.ViewModels.Device;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ElectroParts.ViewModels.Part;

    public class DevicesController : BaseController
    {
        private readonly IDeviceService deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
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

    }
}


