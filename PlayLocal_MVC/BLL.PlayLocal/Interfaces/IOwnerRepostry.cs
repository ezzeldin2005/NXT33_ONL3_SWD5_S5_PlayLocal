using DAL.PlayLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayLocal.Interfaces
{
    public interface IOwnerRepostry
    {
        public int AddOwner(Owner owner);

        public int UpdateOwner(Owner owner);

        public int DeleteOwner(string Id);

        public Owner GetOwnerById(string Id);

        public IEnumerable<Owner> GetAllOwners();

        IEnumerable<Venue> GetVenuesByOwnerId(string ownerId);
    }
}
