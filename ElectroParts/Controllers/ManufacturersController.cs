namespace ElectroParts.Controllers
{
    using ElectroParts.Common;
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.Manufacturer.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturersController(
            IManufacturerService manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        public async Task<IActionResult> Index()
        {
            var requestData = new GetManufacturersRequestData
            {
                SkipEntries = ApplicationConstants.DefaultSkipEntries,
                TakeEntries = ApplicationConstants.DefaultTakeEntries
            };

            var manufacturers = await manufacturerService.GetAllAsync(requestData);

            return View(manufacturers);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    AddManufacturerRequestData requestData)
        {
            if (!ModelState.IsValid)
            {
                return View(requestData);
            }

            await manufacturerService.AddAsync(requestData);

            return RedirectToAction(nameof(Index));
        }

    }
}