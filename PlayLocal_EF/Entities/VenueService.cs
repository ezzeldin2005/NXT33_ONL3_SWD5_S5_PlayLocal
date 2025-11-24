using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Entities
{
    internal class VenueService
    {
        public string ServiceID { get; set; }
        public string ServiceType { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }

        public string VenueID { get; set; } // Foreign Key للمكان
        public Venue Venue { get; set; } // Navigation Property للمكان
    }
}
