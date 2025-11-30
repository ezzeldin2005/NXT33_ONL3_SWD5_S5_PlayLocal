using BLL.PlayLocal.Interfaces;
using DAL.PlayLocal.Contexts;
using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Repostries
{
    public class BookingRepostiory : IBookingRepository
    {
        private readonly PlayLocalDBcontext _context;

        public BookingRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }
        public int AddBooking(Booking booking)
        {
           _context.Bookings.Add(booking);
              
            return _context.SaveChanges();
        }

        public int CancelBooking(string bookingId)
        {
            Booking? bookingToCancel = _context.Bookings.Find(bookingId);

            if (bookingToCancel == null)
            {
                return 0; // Booking not found
            }
            else
            {
                _context.Bookings.Remove(bookingToCancel);
            }

            return _context.SaveChanges();
        }

        public Booking GetBookingById(string bookingId)
        {
          Booking? bookingToFind =  _context.Bookings.Find(bookingId);
            
            return bookingToFind;
        }

        public IEnumerable<Booking> GetBookingsByCourtId(string courtId) //Readonly
        {
            
            List<Booking> bookings = _context.Bookings.AsNoTracking().Where(b => b.CourtID == courtId).ToList();

            return bookings;
        }

        public IEnumerable<Booking> GetBookingsByPlayerId(string playerId) //Readonly
        {

            List<Booking> bookings = _context.Bookings.AsNoTracking().Where(b => b.PlayerID == playerId).ToList();

            return bookings;
        }

        public bool IsCourtAvailable(string courtId, DateTime date, TimeSpan start, TimeSpan end)
        {
            return !_context.Bookings.Any(b =>
                                                b.CourtID == courtId &&
                                                b.BookingDate == date &&
                                             (
                                                (start >= b.StartTime && start < b.EndTime) ||
                                                (end > b.StartTime && end <= b.EndTime) ||
                                                (start <= b.StartTime && end >= b.EndTime)
                                             )
                                         );
        }

        public int UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);

            return _context.SaveChanges();
        }
    }
}
