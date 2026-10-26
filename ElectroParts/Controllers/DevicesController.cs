
using ElectroParts.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ElectroParts.Controllers
{
    public class DevicesController : BaseController
    {
        private readonly IDeviceService deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

