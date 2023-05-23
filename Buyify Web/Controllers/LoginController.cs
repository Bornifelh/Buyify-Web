using Microsoft.AspNetCore.Mvc;

namespace Buyify_Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
