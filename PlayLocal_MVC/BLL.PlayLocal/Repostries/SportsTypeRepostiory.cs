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
    public class SportsTypeRepostiory : ISportsTypeRepository
    {
        private readonly PlayLocalDBcontext _context;

        public SportsTypeRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }

        public IEnumerable<SportsType> GetAllSports()
        {
            List<SportsType> sportsTypes = _context.SportsTypes.ToList();
            return sportsTypes;
        }
    }
}
