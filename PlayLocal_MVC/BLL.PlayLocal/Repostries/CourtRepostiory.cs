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
    public class CourtRepostiory : ICourtRepository
    {
        private readonly PlayLocalDBcontext _context;

        public CourtRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }

        public int AddCourt(Court court)
        {
            _context.Courts.Add(court);
            return _context.SaveChanges();
        }

        public void AddSportsToCourt(string courtId, IEnumerable<string> sportsIds)
        {
            var court = _context.Courts
                                    .Include(c => c.SportsTypes)
                                    .FirstOrDefault(c => c.CourtID == courtId);

            if (court != null)
            {
                foreach (var sportId in sportsIds)
                {
                    var sport = _context.SportsTypes.Find(sportId);
                    court.SportsTypes.Add(sport);
                }

                _context.SaveChanges();
            }


        }

        public int DeleteCourt(string courtId)
        {
            Court? courtToDelete = _context.Courts.Find(courtId);
            if (courtToDelete == null)
            {
                return 0; // Court not found
            }
            else
            {
                _context.Courts.Remove(courtToDelete);
                return _context.SaveChanges();
            }
        }

        public Court GetCourtById(string courtId)
        {
            Court? courtToFind = _context.Courts.Find(courtId);

            return courtToFind;
        }

        

        public void RemoveSportsFromCourt(string courtId, IEnumerable<string> sportsIds)
        {
            var court = _context.Courts
                .Include(c => c.SportsTypes) 
                .FirstOrDefault(c => c.CourtID == courtId);

            if (court != null)
            {
                var sportIdsToRemove = sportsIds.ToList();

                // Remove matching sports
                var sportsToRemove = court.SportsTypes
                    .Where(st => sportIdsToRemove.Contains(st.SportId))
                    .ToList();

                foreach (var sport in sportsToRemove)
                {
                    court.SportsTypes.Remove(sport);
                }

                _context.SaveChanges();
            }
               
        }

        public int UpdateCourt(Court court)
        {
            _context.Courts.Update(court);
            return _context.SaveChanges();
        }
    }
}
