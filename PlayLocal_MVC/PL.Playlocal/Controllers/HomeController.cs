using BLL.PlayLocal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Playlocal.ViewModels;

namespace PL.Playlocal.Controllers
{
    public class HomeController : Controller
    {
        readonly private IPlayerRepository _playerRepository;
        readonly private IOwnerRepostry _ownerRepository;
        public HomeController(IPlayerRepository playerRepository, IOwnerRepostry ownerRepository)
        {
            _playerRepository = playerRepository;
            _ownerRepository = ownerRepository;
        }
        public IActionResult LandingPage()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // Clear everything from session
            HttpContext.Session.Clear();
            return RedirectToAction("LandingPage", "Home");
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // find  Players first
            var player =  _playerRepository.GetPlayerByEmail(model.Email);

            if (player != null && model.Password == player.passwordHash)
            {
                // Success → Store user type in session
                HttpContext.Session.SetString("UserType", "Player");
                HttpContext.Session.SetString("UserId", player.PlayerID);
                HttpContext.Session.SetString("UserName", player.FullName);
                return RedirectToAction("PlayerHome", "Player"); // or create later
            }

            // Then try Owners
            var owner = _ownerRepository.GetOwnerByEmail(model.Email);

            if (owner != null && owner.Password == model.Password)
            {
                HttpContext.Session.SetString("UserType", "Owner");
                HttpContext.Session.SetString("UserId", owner.OwnerID);
                HttpContext.Session.SetString("UserName", owner.FullName);
                return RedirectToAction("OwnerHome", "Owner"); // or create later
            }

            ModelState.AddModelError("", "Invalid email or password.");

            return View(model);
        }
        #endregion

        #region Create Player&Owner
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel vm)
        {
            if(ModelState.IsValid)
            {
                if(vm.AccountType == AccountType.Player)
                {
                    var player = vm.ToPlayer();
                    _playerRepository.AddPlayer(player);
                }
                else if(vm.AccountType == AccountType.Owner)
                {
                    var owner = vm.ToOwner();
                    _ownerRepository.AddOwner(owner);
                }
                TempData["Success"] = "Account created successfully! Please log in.";
                return RedirectToAction("Login");
            }
            return View(vm);
        }

        #endregion
    }
}
