
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElectroParts.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated =>
            this.User?.Identity?.IsAuthenticated ?? false;

        protected string? GetUserId() =>
            this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}

