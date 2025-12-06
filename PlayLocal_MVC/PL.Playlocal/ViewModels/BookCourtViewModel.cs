// PL.Playlocal.ViewModels/BookCourtViewModel.cs
using BLL.PlayLocal.Interfaces;
using DAL.PlayLocal.Models;
using System.ComponentModel.DataAnnotations;

namespace PL.Playlocal.ViewModels
{
    public class BookCourtViewModel
    {
        public string CourtID { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public double PricePerHour { get; set; }

        [Required]
        public DateTime BookingDate { get; set; } = DateTime.Today;

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public List<TimeSpan> AvailableSlots { get; set; } = new();
        public List<TimeSpan> BookedSlots { get; set; } = new();
    }

    public static class BookingExtensions
    {
        public static void LoadAvailableSlots(this BookCourtViewModel vm, Court court, IBookingRepository bookingRepo, DateTime date)
        {
            var workingHours = court.Venue.VenueWorkingHours
                .FirstOrDefault(h => h.DayOfWeek == date.DayOfWeek);

            if (workingHours == null)
            {
                vm.AvailableSlots = new();
                vm.BookedSlots = new();
                return;
            }

            var slots = new List<TimeSpan>();
            for (var time = workingHours.OpenTime; time < workingHours.CloseTime; time = time.Add(TimeSpan.FromHours(1)))
            {
                slots.Add(time);
            }

            vm.AvailableSlots = slots;

            vm.BookedSlots = bookingRepo.GetBookingsByCourtAndDate(court.CourtID, date)
                                        .Select(b => b.StartTime)
                                        .ToList();
        }

        public static bool HasConflict(this BookCourtViewModel vm, IBookingRepository bookingRepo)
        {
            return bookingRepo.GetBookingsByCourtAndDate(vm.CourtID, vm.BookingDate)
                              .Any(b =>
                                  vm.StartTime < b.EndTime && vm.EndTime > b.StartTime);
        }

        public static Booking ToBooking(this BookCourtViewModel vm, string playerId)
        {
            var hours = (vm.EndTime - vm.StartTime).TotalHours;

            return new Booking
            {
                BookingID = Guid.NewGuid().ToString(),
                BookingDate = vm.BookingDate,
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                Status = (DAL.PlayLocal.Models.BookingStatus)BookingStatus.Pending,
                AmountPaid = vm.PricePerHour * hours,
                PaymentMethod = "Online",
                PaymentStatus = PaymentStatus.Pending,
                PlayerID = playerId,
                CourtID = vm.CourtID,
                Rating = 0
            };
        }
    }
}