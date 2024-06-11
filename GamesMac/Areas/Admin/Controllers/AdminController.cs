using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesMac.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
