using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Models
{
    public class Player
    {
        public string PlayerID { get; set; }
        public string FullName { get; set; }

        public string? Address { get; set; }

        public string passwordHash { get; set; }

        public string? Hobby { get; set; }

        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfilePictureUrl { get; set; }

        //relationships

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>(); // Navigation Property للحجوزات اللي اللاعب عملها


    }
}
