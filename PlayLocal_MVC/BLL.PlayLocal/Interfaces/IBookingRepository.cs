using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface IBookingRepository
    {
        int AddBooking(Booking booking);
        int UpdateBooking(Booking booking);
        int CancelBooking(string bookingId);

        Booking GetBookingById(string bookingId);
        IEnumerable<Booking> GetBookingsByPlayerId(string playerId);
        IEnumerable<Booking> GetBookingsByCourtId(string courtId);

        // System logic requirement
        bool IsCourtAvailable(string courtId, DateTime date, TimeSpan start, TimeSpan end);
        IEnumerable<Booking> GetBookingsByCourtAndDate(string courtId, DateTime date);
        IEnumerable<Booking> GetAllBookings();
    }

}
