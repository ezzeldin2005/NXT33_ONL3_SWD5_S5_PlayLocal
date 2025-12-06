// PL.Playlocal.ViewModels/BookingViewModel.cs
using DAL.PlayLocal.Models;

namespace PL.Playlocal.ViewModels
{

    public enum BookingStatus
    {
        Pending = 1,     // بانتظار التأكيد
        Confirmed = 2,   // مؤكد
        Cancelled = 3,   // ملغي
        Completed = 4    // مكتمل بعد انتهاء الحجز
    }
    public class BookingViewModel
    {
        public string BookingID { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public string VenueAddress { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public BookingStatus Status { get; set; }
        public double AmountPaid { get; set; }
        public string StatusBadgeClass => Status switch
        {
            BookingStatus.Pending => "bg-warning text-dark",
            BookingStatus.Confirmed => "bg-success",
            BookingStatus.Cancelled => "bg-danger",
            BookingStatus.Completed => "bg-secondary",
            _ => "bg-light text-dark"
        };
    }

    public static class BookingExtensions2
    {
        public static BookingViewModel ToViewModel(this Booking booking)
        {
            return new BookingViewModel
            {
                BookingID = booking.BookingID,
                CourtName = booking.Court?.Name ?? "Unknown Court",
                VenueName = booking.Court?.Venue?.Name ?? "Unknown Venue",
                VenueAddress = booking.Court?.Venue?.Address ?? "",
                BookingDate = booking.BookingDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                Status = (BookingStatus)booking.Status,
                AmountPaid = booking.AmountPaid
            };
        }

        public static List<BookingViewModel> ToViewModelList(this IEnumerable<Booking> bookings)
        {
            return bookings.Select(b => b.ToViewModel()).ToList();
        }
    }
}