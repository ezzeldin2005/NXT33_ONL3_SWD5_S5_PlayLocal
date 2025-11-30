using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface IVenueRepository
    {
        int AddVenue(Venue venue);
        int UpdateVenue(Venue venue);
        int DeleteVenue(string venueId);
        
        Venue GetVenueById(string venueId);
        IEnumerable<Venue> GetAllVenues();

        IEnumerable<VenueWorkingHours> GetWorkingHoursByVenueId(string venueId);
        IEnumerable<Court> GetCourtsByVenueId(string venueId);
    }

}
