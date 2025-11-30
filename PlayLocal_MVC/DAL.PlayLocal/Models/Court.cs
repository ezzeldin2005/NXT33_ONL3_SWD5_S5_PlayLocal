using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Models
{
    public class Court
    {
        public string CourtID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double PricePerHour { get; set; }
        public bool Is_Available { get; set; }
        public string Environment { get; set; } // indoor , outdoor
        public string Surface { get; set; } // عشب، ترتان، ...
        public int Size { get; set; } // خماسي , رباعي , ...
        
        public string VenueID { get; set; } // Foreign Key للمكان
        public Venue Venue { get; set; } // Navigation Property للمكان

        public ICollection<CourtPhoto> CourtPhotos { get; set; } = new HashSet<CourtPhoto>(); // Navigation Property لصور الملعب
        public ICollection<SportsType> SportsTypes { get; set; } = new HashSet<SportsType>(); // Navigation Property لأنواع الرياضات اللي الملعب بيدعمها

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>(); // Navigation Property للحجوزات اللي اتعملت على الملعب
    }
}
