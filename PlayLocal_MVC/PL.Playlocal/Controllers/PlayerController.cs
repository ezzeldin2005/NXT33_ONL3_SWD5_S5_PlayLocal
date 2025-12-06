using BLL.PlayLocal.Interfaces;
using BLL.PlayLocal.Repostries;
using Microsoft.AspNetCore.Mvc;
using PL.Playlocal.ViewModels;
using DalBookingStatus = DAL.PlayLocal.Models.BookingStatus;

namespace PL.Playlocal.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ICourtRepository _courtRepo;
        private readonly IVenueRepository _venueRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(ICourtRepository courtRepo, IVenueRepository venueRepo, IBookingRepository bookingRepo, IPlayerRepository playerRepository)
        {
            _courtRepo = courtRepo;
            _venueRepo = venueRepo;
            _bookingRepo = bookingRepo;
            _playerRepository = playerRepository;
        }
        public IActionResult PlayerHome()
        {
            // Check if user is logged in as Player
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Home");

            // Pass the name directly to ViewBag
            ViewBag.UserName = HttpContext.Session.GetString("UserName")
                               ?? "Player";

            var courts = _courtRepo.GetAllCourts()
                              .Where(c => c.Is_Available);

            var vm = courts.Select(c => c.ToViewModel()).ToList();

            ViewBag.VenueInfo = courts.ToDictionary(
            c => c.CourtID,
            c => new { Name = c.Venue.Name, Address = c.Venue.Address }
            );

            return View(vm);
        }

        #region Add Booking
        [HttpGet]
        public IActionResult BookCourt(string courtId)
        {
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Home");

            var court = _courtRepo.GetCourtById(courtId);

            if (court == null || !court.Is_Available) return NotFound();

            var vm = new BookCourtViewModel
            {
                CourtID = court.CourtID,
                CourtName = court.Name,
                VenueName = court.Venue.Name,
                PricePerHour = court.PricePerHour
            };

            vm.LoadAvailableSlots(court, _bookingRepo, DateTime.Today);

            return View(vm);
        }

        [HttpPost]
        public IActionResult BookCourt(BookCourtViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var court = _courtRepo.GetCourtById(vm.CourtID);
                vm.LoadAvailableSlots(court!, _bookingRepo, vm.BookingDate);
                return View(vm);
            }

            if (vm.HasConflict(_bookingRepo))
            {
                ModelState.AddModelError("", "This time slot is already booked!");
                var court = _courtRepo.GetCourtById(vm.CourtID);
                vm.LoadAvailableSlots(court!, _bookingRepo, vm.BookingDate);
                return View(vm);
            }

            var playerId = HttpContext.Session.GetString("UserId");

            var booking = vm.ToBooking(playerId!);

            _bookingRepo.AddBooking(booking);

            TempData["Success"] = "Court booked successfully!";
            return RedirectToAction("MyBookings");
        }
        #endregion

        #region Display of Booking
        [HttpGet]
        public IActionResult MyBookings()
        {
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Home");

            var playerId = HttpContext.Session.GetString("UserId");

            var bookings = _bookingRepo.GetBookingsByPlayerId(playerId!);

            var vm = bookings.ToViewModelList();

            ViewBag.UserName = HttpContext.Session.GetString("UserName") ?? "Player";

            return View(vm);
        }
        #endregion

        #region Cancel Booking
        [HttpGet]
        public IActionResult CancelBookingConfirmed(string id)
        {
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Home");

            var playerId = HttpContext.Session.GetString("UserId");
            var booking = _bookingRepo.GetBookingById(id);

            if (booking == null || booking.PlayerID != playerId)
                return NotFound();

            var vm = booking.ToViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CancelBookingConfirmed")]
        public IActionResult CancelBookingConfirmed2(string bookingId)
        {
            var playerId = HttpContext.Session.GetString("UserId");
            var booking = _bookingRepo.GetBookingById(bookingId);

            if (booking == null || booking.PlayerID != playerId)
                return NotFound();

            if (booking.Status == DalBookingStatus.Pending || booking.Status == DalBookingStatus.Confirmed)
            {
                _bookingRepo.CancelBooking(bookingId);
                TempData["Success"] = "Booking cancelled successfully.";
            }
            else
            {
                TempData["Error"] = "This booking cannot be cancelled.";
            }

            return RedirectToAction("MyBookings");
        }
        #endregion

        [HttpGet]
        public JsonResult GetAvailableSlots(string courtId, DateTime date)
        {
            var court = _courtRepo.GetCourtById(courtId);

            if (court == null) return Json(new { availableSlots = new List<string>(), bookedSlots = new List<string>() });

            var dayOfWeek = date.DayOfWeek;
            var workingHours = court.Venue.VenueWorkingHours
                .FirstOrDefault(h => h.DayOfWeek == dayOfWeek);

            var available = new List<string>();
            var booked = new List<string>();

            if (workingHours != null)
            {
                for (var time = workingHours.OpenTime; time < workingHours.CloseTime; time = time.Add(TimeSpan.FromHours(1)))
                {
                    available.Add(time.ToString(@"hh\:mm"));
                }

                booked = _bookingRepo.GetBookingsByCourtAndDate(courtId, date)
                                    .Select(b => b.StartTime.ToString(@"hh\:mm"))
                                    .ToList();
            }

            return Json(new { availableSlots = available, bookedSlots = booked });
        }

        #region Profile
        [HttpGet]
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("UserType") != "Player")
                return RedirectToAction("Login", "Account");

            var playerId = HttpContext.Session.GetString("UserId");

            var player = _playerRepository.GetPlayerById(playerId); 
            if (player == null) return NotFound();

            var vm = player.ToProfileViewModel();
            return View(vm);
        }
        #endregion
    }
}
