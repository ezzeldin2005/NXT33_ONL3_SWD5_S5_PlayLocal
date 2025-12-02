using Microsoft.AspNetCore.Mvc;

namespace PL.Playlocal.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult PlayerHome()
        {
            // Check if user is logged in as Player
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Home");

            // Pass the name directly to ViewBag
            ViewBag.UserName = HttpContext.Session.GetString("UserName")
                               ?? "Player"; 
            return View();
        }
    }
}
