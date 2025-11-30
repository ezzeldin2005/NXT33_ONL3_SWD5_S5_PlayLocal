using Microsoft.AspNetCore.Mvc;

namespace PL.Playlocal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
