using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Entities
{
    internal class Venue
    {
        public string VenueID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public string? GoogleMapsLink { get; set; }
        public string MainContactPhone { get; set; } // رقم التليفون الرئيسي للمكان
        public bool HasEquipmentRental { get; set; } // هل المكان بيأجر معدات
        public TimeSpan OpenTime { get; set; } // فاتح من امتى
        public TimeSpan CloseTime { get; set; } // هيقفل امتى
        public string CloseDay { get; set; } // اليوم اللي بيقفل فيه المكان
    
        
        public string OwnerID { get; set; } // Foreign Key لصاحب المكان
        public Owner Owner { get; set; } // Navigation Property لصاحب المكان

        public ICollection<Court> Courts { get; set; } = new HashSet<Court>();// Navigation Property للملاعب اللي في المكان
        public ICollection<VenueService> VenueServices { get; set; } = new HashSet<VenueService>(); // Navigation Property للخدمات اللي بيقدمها المكان
    }
}
