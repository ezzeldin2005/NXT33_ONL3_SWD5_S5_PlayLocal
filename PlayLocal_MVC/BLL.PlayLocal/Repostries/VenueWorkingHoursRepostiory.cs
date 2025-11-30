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

        public int DeleteWorkingHours(string id)
        {
            VenueWorkingHours? hours = _context.VenueWorkingHours.Find(id);
            if (hours != null)
            {
                _context.VenueWorkingHours.Remove(hours);
                return _context.SaveChanges();
            }
            return 0;
        }

        
        public int UpdateWorkingHours(VenueWorkingHours hours)
        {
            _context.VenueWorkingHours.Update(hours);
            return _context.SaveChanges();
        }
    }
}
