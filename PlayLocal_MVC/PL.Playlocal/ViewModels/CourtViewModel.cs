// PL.Playlocal.ViewModels/CourtViewModel.cs
using DAL.PlayLocal.Models;
using System.ComponentModel.DataAnnotations;

namespace PL.Playlocal.ViewModels
{
    public class CourtViewModel
    {
        public string CourtID { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(50, 1000)]
        public double PricePerHour { get; set; }

        public bool Is_Available { get; set; } = true;

        [Required]
        public string Environment { get; set; } // indoor, outdoor

        [Required]
        public string Surface { get; set; } // عشب, ترتان, etc.

        [Required]
        public int Size { get; set; } // 5, 7, 11

        public string VenueID { get; set; }

        public List<string> SelectedSportIds { get; set; } = new();
        public List<SportsType> AvailableSports { get; set; } = new();
    }

    public static class CourtExtensions
    {
        public static CourtViewModel ToViewModel(this Court court)
        {
            return new CourtViewModel
            {
                CourtID = court.CourtID,
                Name = court.Name,
                Description = court.Description,
                PricePerHour = court.PricePerHour,
                Is_Available = court.Is_Available,
                Environment = court.Environment,
                Surface = court.Surface,
                Size = court.Size,
                VenueID = court.VenueID,
                SelectedSportIds = court.SportsTypes.Select(s => s.SportId).ToList(),
                AvailableSports = court.SportsTypes.ToList()
            };
        }

        public static Court ToCourt(this CourtViewModel vm)
        {
            return new Court
            {
                CourtID = string.IsNullOrEmpty(vm.CourtID) ? Guid.NewGuid().ToString() : vm.CourtID,
                Name = vm.Name,
                Description = vm.Description,
                PricePerHour = vm.PricePerHour,
                Is_Available = vm.Is_Available,
                Environment = vm.Environment,
                Surface = vm.Surface,
                Size = vm.Size,
                VenueID = vm.VenueID
            };
        }
    }
}