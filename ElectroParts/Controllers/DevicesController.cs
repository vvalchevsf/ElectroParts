
namespace ElectroParts.Controllers
{
    using ElectroParts.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using ElectroParts.Common;
    using ElectroParts.Services.DTOs.Device.Request;
    using ElectroParts.ViewModels.Device;
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


    }
}


