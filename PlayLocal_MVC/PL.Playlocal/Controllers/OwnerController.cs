using BLL.PlayLocal.Interfaces;
using BLL.PlayLocal.Repostries;
using DAL.PlayLocal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Playlocal.ViewModels;

namespace PL.Playlocal.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IVenueWorkingHoursRepository _venueWorkingHoursRepository;
        private readonly ICourtRepository _courtRepository;
        private readonly ISportsTypeRepository _sportRepository;

        public OwnerController(IVenueRepository venueRepository, IVenueWorkingHoursRepository venueWorkingHoursRepository, ICourtRepository courtRepository, ISportsTypeRepository sportRepository)
        {
            _venueRepository = venueRepository;
            _venueWorkingHoursRepository = venueWorkingHoursRepository;
            _courtRepository = courtRepository;
            _sportRepository = sportRepository;
        }
        public IActionResult OwnerHome()
        {
            // Check if user is logged in as Player
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            // Pass the name directly to ViewBag
            ViewBag.UserName = HttpContext.Session.GetString("UserName")
                               ?? "Owner";

            var ownerId = HttpContext.Session.GetString("UserId");

            var venues = _venueRepository.GetAllVenues()
                                     .Where(v => v.OwnerID == ownerId)
                                     .ToList();

            var venueViewModel = venues.ToViewModelList();

            return View(venueViewModel);
        }

        #region Venue Section
        #region Add Venue
        //Create Venue
        [HttpGet]
        public IActionResult AddVenue()
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Account");
            var model = new VenueViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddVenue(VenueViewModel vm)
        {
            var ownerId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrWhiteSpace(ownerId))
            {
                ModelState.AddModelError("", "Session expired. Please log in again.");
                return View(vm);
            }

            vm.OwnerID = ownerId;

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Convert ViewModel to Model

            var venue = vm.ToVenue();

            try
            {
                // Save to database
                int result = _venueRepository.AddVenue(venue);

                if (result > 0)
                {
                    TempData["Success"] = $"Venue '{venue.Name}' has been added successfully!";
                    return RedirectToAction("OwnerHome");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add venue. Please try again.");
                    return View(vm);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "DB Error: " + ex.InnerException?.Message);
            }
            return View(vm);
        }

        #endregion

        #region Delete Venue

        #endregion

        #region Edit Venue
        [HttpGet]
        public IActionResult EditVenue(string id)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            var venue = _venueRepository.GetAllVenues()
                                        .FirstOrDefault(v => v.VenueID == id);

            if (venue == null || venue.OwnerID != HttpContext.Session.GetString("UserId"))
                return NotFound();

            var vm = venue.ToViewModel();

            return View(vm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditVenue([FromRoute] string? Id, VenueViewModel vm)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");


            if (!ModelState.IsValid)
                return View(vm);

            var existingVenue = _venueRepository.GetAllVenues()
                                                .FirstOrDefault(v => v.VenueID == Id);

            if (existingVenue == null || existingVenue.OwnerID != HttpContext.Session.GetString("UserId"))
                return NotFound();

            // Update main fields
            existingVenue.Name = vm.Name;
            existingVenue.Address = vm.Address;
            existingVenue.Description = vm.Description;
            existingVenue.GoogleMapsLink = vm.GoogleMapsLink;
            existingVenue.MainContactPhone = vm.MainContactPhone;
            existingVenue.HasEquipmentRental = vm.HasEquipmentRental;

            // Update working hours: delete old, add new
            _venueWorkingHoursRepository.DeleteWorkingHours(vm.VenueID);

            existingVenue.VenueWorkingHours = vm.WorkingHours
                .Select(h => new VenueWorkingHours
                {
                    VenueWorkingHoursID = Guid.NewGuid().ToString(),
                    DayOfWeek = h.DayOfWeek,
                    OpenTime = h.OpenTime,
                    CloseTime = h.CloseTime,
                    VenueID = vm.VenueID
                })
                .ToList();

            int result = _venueRepository.UpdateVenue(existingVenue);

            if (result > 0)
            {
                TempData["Success"] = $"Venue '{vm.Name}' updated successfully!";
                return RedirectToAction("OwnerHome");
            }

            ModelState.AddModelError("", "Failed to update venue.");
            return View(vm);
        }
        #endregion

        #region Delete Venue
        [HttpGet]
        public IActionResult DeleteVenue(string id)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Account");

            var venue = _venueRepository.GetAllVenues()
                                        .FirstOrDefault(v => v.VenueID == id);

            if (venue == null || venue.OwnerID != HttpContext.Session.GetString("UserId"))
                return NotFound();

            var vm = venue.ToViewModel();
            return View(vm);
        }

        [HttpPost]
        [ActionName("DeleteVenue")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVenueConfirmed(string venueId)
        {
            if (string.IsNullOrEmpty(venueId))
                return NotFound();

            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Account");

            var venue = _venueRepository.GetAllVenues()
                                        .FirstOrDefault(v => v.VenueID == venueId);

            if (venue == null || venue.OwnerID != HttpContext.Session.GetString("UserId"))
                return NotFound();

            try
            {
                // 1. Delete Working Hours
                if (venue.VenueWorkingHours?.Any() == true)
                    _venueWorkingHoursRepository.DeleteWorkingHours(venueId);

                // 2. Delete Courts (if exists)
                if (venue.Courts?.Any() == true)
                    _courtRepository.DeleteCourtsByVenueId(venueId);  // you'll add this method

                // 3. Delete the Venue itself
                int result = _venueRepository.DeleteVenue(venueId);

                if (result > 0)
                {
                    TempData["Success"] = $"Venue '{venue.Name}' has been deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Failed to delete venue.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error deleting venue: " + ex.Message;
            }

            return RedirectToAction("OwnerHome");
        }
        #endregion
        #endregion

        #region Court Section
        public IActionResult CourtsPage(string venueId) {

            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            var ownerId = HttpContext.Session.GetString("UserId");

            var venue = _venueRepository.GetAllVenues()
                                  .FirstOrDefault(v => v.VenueID == venueId && v.OwnerID == ownerId);


            if (venue == null) return NotFound();


            var courts = _venueRepository.GetCourtsByVenueId(venueId);

            var vm = courts.Select(c => c.ToViewModel()).ToList();

            ViewBag.VenueName = venue.Name;
            ViewBag.VenueID = venueId;

            return View(vm);
        }

        #region Add Court
        [HttpGet]
        public IActionResult AddCourt(string venueId)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            var vm = new CourtViewModel
            {
                VenueID = venueId,
                AvailableSports = _sportRepository.GetAllSports().OrderBy(s => s.Name).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddCourt(CourtViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableSports = _sportRepository.GetAllSports().ToList();
                return View(vm);
            }

            var court = vm.ToCourt();
            int result = _courtRepository.AddCourt(court);

            if (result > 0 && vm.SelectedSportIds.Any())
            {
                _courtRepository.AddSportsToCourt(court.CourtID, vm.SelectedSportIds);
            }

            TempData["Success"] = $"Court '{vm.Name}' added successfully!";
            return RedirectToAction("CourtsPage", new { venueId = vm.VenueID });
        }
        #endregion

        #region Edit Court
        [HttpGet]
        public IActionResult EditCourt(string id)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            var ownerId = HttpContext.Session.GetString("UserId");

            var court = _courtRepository.GetCourtById(id);

            if (court == null)
                return NotFound();

            var vm = court.ToViewModel();

            vm.AvailableSports = _sportRepository.GetAllSports().ToList();

            ViewBag.VenueID = court.VenueID;

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditCourt(CourtViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableSports = _sportRepository.GetAllSports().ToList();
                return View(vm);
            }

            var existingCourt = _courtRepository.GetCourtById(vm.CourtID);

            if (existingCourt == null)
                return NotFound();

            // Update main fields
            existingCourt.Name = vm.Name;
            existingCourt.Description = vm.Description;
            existingCourt.PricePerHour = vm.PricePerHour;
            existingCourt.Is_Available = vm.Is_Available;
            existingCourt.Environment = vm.Environment;
            existingCourt.Surface = vm.Surface;
            existingCourt.Size = vm.Size;

            // Update sports: remove all then add selected
            _courtRepository.RemoveSportsFromCourt(vm.CourtID, existingCourt.SportsTypes.Select(s => s.SportId));
            if (vm.SelectedSportIds.Any())
                _courtRepository.AddSportsToCourt(vm.CourtID, vm.SelectedSportIds);

            int result = _courtRepository.UpdateCourt(existingCourt);

            if (result > 0)
            {
                TempData["Success"] = $"Court '{vm.Name}' updated successfully!";
                return RedirectToAction("CourtsPage", new { venueId = vm.VenueID });
            }

            ModelState.AddModelError("", "Failed to update court.");
            vm.AvailableSports = _sportRepository.GetAllSports().ToList();
            return View(vm);
        }
        #endregion

        #region Delete Court
        [HttpGet]
        public IActionResult DeleteCourt(string id)
        {
            if (HttpContext.Session.GetString("UserType") != "Owner")
                return RedirectToAction("Login", "Home");

            var court = _courtRepository.GetCourtById(id);

            if (court == null)
                return NotFound();

            var vm = court.ToViewModel();

            ViewBag.VenueID = court.VenueID;

            return View(vm);
        }

        [HttpPost]
        [ActionName("DeleteCourt")]
        public IActionResult DeleteCourtConfirmed(string courtId)
        {
            var court = _courtRepository.GetCourtById(courtId);

            if (court == null)
                return NotFound();

            int result = _courtRepository.DeleteCourt(courtId);

            if (result > 0)
                TempData["Success"] = $"Court '{court.Name}' deleted successfully!";
            else
                TempData["Error"] = "Failed to delete court.";

            return RedirectToAction("CourtsPage", new { venueId = court.VenueID });
        }
        #endregion
        #endregion

    }
}
