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
    public class VenueRepostiory :IVenueRepository
    {
        private readonly PlayLocalDBcontext _context;

        public VenueRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }

        public int AddVenue(Venue venue)
        {
            _context.Venues.Add(venue);
            return _context.SaveChanges();
        }

        public int DeleteVenue(string venueId)
        {
           Venue? venueToDelete =  _context.Venues.Find(venueId);

            if (venueToDelete != null)
            {
                _context.Venues.Remove(venueToDelete);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Venue> GetAllVenues() //Readonly
        {
           List<Venue> venues =  _context.Venues.AsNoTracking()
                .Include(v => v.VenueWorkingHours)
                .Include(v => v.Courts)
                .ToList();

            return venues;
        }

        public IEnumerable<Court> GetCourtsByVenueId(string venueId) //Readonly
        {
            List<Court> courts = _context.Courts.AsNoTracking().Where(c => c.VenueID == venueId).
                                 Include(c => c.SportsTypes)
                                .ToList();
            return courts;
        }

        public Venue GetVenueById(string venueId)
        {
            Venue? venueToFind = _context.Venues.Find(venueId);
            return venueToFind;
        }

        
        public int UpdateVenue(Venue venue)
        {
            var existing = _context.Venues
            .Include(v => v.VenueWorkingHours)
            .FirstOrDefault(v => v.VenueID == venue.VenueID);

            if (existing == null) return 0;

            // Update scalar properties
            _context.Entry(existing).CurrentValues.SetValues(venue);

            // Replace working hours (you already delete + add new)
            // So just clear and add
            existing.VenueWorkingHours.Clear();
            
            foreach (var wh in venue.VenueWorkingHours)
            {
                existing.VenueWorkingHours.Add(wh);
            }
            return _context.SaveChanges();
        }

        public IEnumerable<VenueWorkingHours> GetWorkingHoursByVenueId(string venueId) //Readonly
        {
            List<VenueWorkingHours> workingHours = _context.VenueWorkingHours.AsNoTracking()
                .Where(wh => wh.VenueID == venueId).ToList();

            return workingHours;
        }
    }
}
