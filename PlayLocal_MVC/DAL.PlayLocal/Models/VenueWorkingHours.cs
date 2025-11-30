using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Models
{
    public class VenueWorkingHours
    {
        public string VenueWorkingHoursID { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // اليوم في الأسبوع
        public TimeSpan OpenTime { get; set; } // وقت الفتح
        public TimeSpan CloseTime { get; set; } // وقت الإغلاق

        //relationships

        public string VenueID { get; set; } // Foreign Key للمكان
        public Venue Venue { get; set; } // Navigation Property للمكان
    }
}
