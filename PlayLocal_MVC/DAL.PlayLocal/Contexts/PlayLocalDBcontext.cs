using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Contexts
{
    public class PlayLocalDBcontext : DbContext
    {
        //Applying Dependency Injection
        public PlayLocalDBcontext(DbContextOptions<PlayLocalDBcontext> options) : base(options)
        {
            
        }

        //Defining DbSets for each entity
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtPhoto> CourtPhotos { get; set; }
        public DbSet<SportsType> SportsTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<VenueWorkingHours> VenueWorkingHours { get; set; }

        public DbSet<Player> Players { get; set; }

        //Configuring the model using Fluent API
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
