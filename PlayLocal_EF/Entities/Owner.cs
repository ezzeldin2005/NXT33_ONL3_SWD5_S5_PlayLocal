using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Entities
{
    internal class Owner
    {
        public string OwnerID { get; set; }
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public ICollection<Venue> Venues { get; set; } = new HashSet<Venue>(); // Navigation Property للأماكن اللي بيملكها
    }
}
