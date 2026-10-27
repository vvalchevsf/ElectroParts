namespace ElectroParts.Controllers
{
    using ElectroParts.Services.Contracts;
    using ElectroParts.Services.DTOs.PartType.Request;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PartTypesController : Controller
    {
        private readonly IPartTypeService partTypeService;

        public PartTypesController(IPartTypeService partTypeService)
        {
            this.partTypeService = partTypeService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPartTypeRequestData request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(request);
            }

            var added = await this.partTypeService.AddAsync(request);

            if (!added)
            {
                this.ModelState.AddModelError(
                    nameof(request.Name),
                    "Вече съществува тип част с това име.");

                return this.View(request);
            }

            return this.RedirectToAction("Create", "Parts");
        }
    }
}

