using BLL.PlayLocal.Interfaces;
using DAL.PlayLocal.Contexts;
using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Repostries
{
    public class VenueWorkingHoursRepostiory : IVenueWorkingHoursRepository
    {
        private readonly PlayLocalDBcontext _context;

        public VenueWorkingHoursRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }

        public int AddWorkingHours(VenueWorkingHours hours)
        {
            _context.VenueWorkingHours.Add(hours);
            return _context.SaveChanges();
        }

        public int DeleteWorkingHours(string venueId)
        {
            var hours = _context.VenueWorkingHours.Where(h => h.VenueID == venueId);
            _context.VenueWorkingHours.RemoveRange(hours);
            return _context.SaveChanges();
        }

        
        public int UpdateWorkingHours(VenueWorkingHours hours)
        {
            _context.VenueWorkingHours.Update(hours);
            return _context.SaveChanges();
        }
    }
}
