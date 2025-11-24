using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Entities
{
    internal class SportsType
    {
        public int SportId { get; set; }
        public string Name { get; set; }

        public ICollection<Court> Courts { get; set; } = new HashSet<Court>(); // Navigation Property للملاعب اللي بيدعم الرياضة دي
    }
}
