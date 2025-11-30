using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Models
{
    public class CourtPhoto
    {
        public string PhotoID { get; set; }
        public string Image { get; set; } // URL or path to the image

        public string Title { get; set; } // عنوان الصورة

        public string CourtID { get; set; } // Foreign Key للملاعب
        public Court Court { get; set; } // Navigation Property للملاعب
    }
}
