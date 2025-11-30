using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
namespace DAL.PlayLocal.Models
{
    public enum BookingStatus
    {
        Pending = 1,     // بانتظار التأكيد
        Confirmed = 2,   // مؤكد
        Cancelled = 3,   // ملغي
        Completed = 4    // مكتمل بعد انتهاء الحجز
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3,
    }
    public class Booking
    {
        public string BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public BookingStatus Status { get; set; } // حالة الحجز (مؤكد، ملغي، مكتمل، إلخ)
        public double Rating { get; set; } // التقييم بعد انتهاء الحجز

        public double AmountPaid { get; set; } // المبلغ المدفوع للحجز

        public string PaymentMethod { get; set; } // طريقة الدفع (بطاقة ائتمان، باي بال، إلخ)

        public PaymentStatus PaymentStatus { get; set; } // حالة الدفع (مدفوع، غير مدفوع، مؤجل، إلخ)

        //relationships

        public string PlayerID { get; set; } // Foreign Key للاعب

        public Player Player { get; set; } // Navigation Property للاعب

        public string CourtID { get; set; } // Foreign Key للملعب
        public Court Court { get; set; } // Navigation Property للملعب

    }
}
