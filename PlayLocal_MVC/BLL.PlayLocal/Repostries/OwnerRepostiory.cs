using BLL.PlayLocal.Interfaces;
using DAL.PlayLocal.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.PlayLocal.Models;

namespace BLL.PlayLocal.Repostries
{
    public class OwnerRepostiory : IOwnerRepostry
    {
        private readonly PlayLocalDBcontext _context;

        //Applying Dependency Injection
        public OwnerRepostiory(PlayLocalDBcontext context)
        {
            _context = context;
        }
        public int AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return _context.SaveChanges();
        }

        public int DeleteOwner(string Id)
        {
            Owner? ownerToDelete = _context.Owners.Find(Id);

            if (ownerToDelete == null)
            {
                return 0; // Owner not found
            }
            else
            {
                _context.Owners.Remove(ownerToDelete);
                return _context.SaveChanges();
            }
        }

        public IEnumerable<Owner> GetAllOwners() //Readonly
        {
            List<Owner> owners = _context.Owners.ToList();
            return owners;
        }

        public Owner GetOwnerById(string Id)
        {
            Owner? ownerToFind = _context.Owners.Find(Id);

            return ownerToFind;
        }

        public int UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
            return _context.SaveChanges();
        }

        public IEnumerable<Venue> GetVenuesByOwnerId(string ownerId)
        {
            List<Venue> venues = _context.Venues.Where(v => v.OwnerID == ownerId).ToList();
            return venues;
        }
    }
}
