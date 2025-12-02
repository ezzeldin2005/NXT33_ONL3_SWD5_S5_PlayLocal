using Microsoft.AspNetCore.Mvc;

namespace PL.Playlocal.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult OwnerHome()
        {
            // Check if user is logged in as Player
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            // Pass the name directly to ViewBag
            ViewBag.UserName = HttpContext.Session.GetString("UserName")
                               ?? "Owner";

            return View();
        }
    }
}
