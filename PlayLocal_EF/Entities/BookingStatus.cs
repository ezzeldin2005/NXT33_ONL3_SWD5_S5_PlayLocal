using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Entities
{
    public enum BookingStatus
    {
        Pending = 0,     // بانتظار التأكيد
        Confirmed = 1,   // مؤكد
        Cancelled = 2,   // ملغي
        Completed = 3    // مكتمل بعد انتهاء الحجز
    }
}
