using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesMac.Controllers
{
    [AllowAnonymous]
    public class ContatoController : Controller
    {
        
        public IActionResult Index()
        {

            return View();
            //codigo que faz com que somente usuarios logados possam ver
            //if (User.Identity.IsAuthenticated)
            //{
              //  return View();
            //}
            //return RedirectToAction("Login", "Account");
        }
    }
}
