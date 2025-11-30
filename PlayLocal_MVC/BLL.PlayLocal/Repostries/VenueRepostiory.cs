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
           List<Venue> venues =  _context.Venues.AsNoTracking().ToList();
            return venues;
        }

        public IEnumerable<Court> GetCourtsByVenueId(string venueId) //Readonly
        {
            List<Court> courts = _context.Courts.AsNoTracking().Where(c => c.VenueID == venueId).ToList();
            return courts;
        }

        public Venue GetVenueById(string venueId)
        {
            Venue? venueToFind = _context.Venues.Find(venueId);
            return venueToFind;
        }

        
        public int UpdateVenue(Venue venue)
        {
            _context.Venues.Update(venue);
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
