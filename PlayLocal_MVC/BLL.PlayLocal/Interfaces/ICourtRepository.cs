using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface ICourtRepository
    {
        int AddCourt(Court court);
        int UpdateCourt(Court court);
        int DeleteCourt(string courtId);

        Court GetCourtById(string courtId);

        void DeleteCourtsByVenueId(string venueId);

        // Manage sports for a court
        void AddSportsToCourt(string courtId, IEnumerable<string> sportsIds);
        void RemoveSportsFromCourt(string courtId, IEnumerable<string> sportsIds);
    }

}
