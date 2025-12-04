
using DAL.PlayLocal.Models;
using System.ComponentModel.DataAnnotations;

namespace PL.Playlocal.ViewModels
{
    public class VenueViewModel
    {
        [ScaffoldColumn(false)]           // ← Hide from forms
        [Editable(false)]                 // ← Extra safety
        public string VenueID { get; set; } = string.Empty;  // ← default empty
  
        [Required(ErrorMessage = "Venue name is required")]
        [StringLength(100)]
        [Display(Name = "Venue Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Full Address")]
        public string Address { get; set; }

        [Display(Name = "Description (Optional)")]
        public string? Description { get; set; }

        [Url(ErrorMessage = "Invalid URL")]
        [Display(Name = "Google Maps Link (Optional)")]
        public string? GoogleMapsLink { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Main Contact Phone")]
        public string MainContactPhone { get; set; }

        [Display(Name = "Equipment Rental Available")]
        public bool HasEquipmentRental { get; set; }

        [ScaffoldColumn(false)]
        public string? OwnerID { get; set; }

        public List<WorkingHoursDay> WorkingHours { get; set; }

        public VenueViewModel()
        {
            // Initialize the list with 7 days
            WorkingHours = new List<WorkingHoursDay>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                WorkingHours.Add(new WorkingHoursDay
                {
                    DayOfWeek = day,
                    IsOpen = true,
                    OpenTime = new TimeSpan(9, 0, 0),   // 9:00 AM
                    CloseTime = new TimeSpan(23, 0, 0)  // 11:00 PM
                });
            }
        }
    }

    public static class VenueViewModelExtensions
    {
        public static Venue ToVenue(this VenueViewModel vm)
        {
            var venue = new Venue
            {
                VenueID = string.IsNullOrEmpty(vm.VenueID) ? Guid.NewGuid().ToString() : vm.VenueID,
                Name = vm.Name,
                Description = vm.Description,
                Address = vm.Address,
                GoogleMapsLink = vm.GoogleMapsLink,
                MainContactPhone = vm.MainContactPhone,
                HasEquipmentRental = vm.HasEquipmentRental,
                OwnerID = vm.OwnerID!,
            };

            // Add working hours
            venue.VenueWorkingHours = vm.WorkingHours
                .Select(h => new VenueWorkingHours
                {
                    VenueWorkingHoursID = Guid.NewGuid().ToString(),
                    DayOfWeek = h.DayOfWeek,
                    OpenTime = h.OpenTime,
                    CloseTime = h.CloseTime,
                    VenueID = venue.VenueID
                })
                .ToList();

            return venue;
        }

        // Add this extension to convert Entity → ViewModel
        public static VenueViewModel ToViewModel(this Venue venue)
        {
            var vm = new VenueViewModel
            {
                VenueID = venue.VenueID,
                Name = venue.Name,
                Description = venue.Description,
                Address = venue.Address,
                GoogleMapsLink = venue.GoogleMapsLink,
                MainContactPhone = venue.MainContactPhone,
                HasEquipmentRental = venue.HasEquipmentRental,
                OwnerID = venue.OwnerID,
            };

            // CLEAR + REBUILD WorkingHours from saved data
            vm.WorkingHours.Clear();

            var savedHours = venue.VenueWorkingHours ?? new List<VenueWorkingHours>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var saved = savedHours.FirstOrDefault(h => h.DayOfWeek == day);

                vm.WorkingHours.Add(new WorkingHoursDay
                {
                    DayOfWeek = day,
                    IsOpen = true,  // Always open now
                    OpenTime = saved?.OpenTime ?? new TimeSpan(9, 0, 0),   // Use saved time
                    CloseTime = saved?.CloseTime ?? new TimeSpan(23, 0, 0) // Use saved time
                });
            }

            return vm;
        }

        public static List<VenueViewModel> ToViewModelList(this IEnumerable<Venue> venues)
        {
            return venues.Select(v => v.ToViewModel()).ToList();
        }
    }

    public class WorkingHoursDay
    {
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsOpen { get; set; } = true;
        public TimeSpan OpenTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan CloseTime { get; set; } = new TimeSpan(23, 0, 0);
    }
}