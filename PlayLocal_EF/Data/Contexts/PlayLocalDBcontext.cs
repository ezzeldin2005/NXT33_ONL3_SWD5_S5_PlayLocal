using Microsoft.EntityFrameworkCore;
using PlayLocal_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Data.Contexts
{
    internal class PlayLocalDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-HCM43M8; Database = PlayLocal; Trusted_Connection = True; Encrypt = False");
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueService> VenueServices { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtPhoto> CourtPhotos { get; set; }
        public DbSet<SportsType> SportsTypes { get; set; }
        
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
