using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Configurations
{
    internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.VenueID); // primary key
            

            builder.Property(v => v.Name)
                     .HasColumnType("nvarchar(100)")
                     .IsRequired();

            builder.Property(v => v.Description)
                        .HasColumnType("nvarchar(500)");

            builder.Property(v => v.Address)
                        .HasColumnType("nvarchar(200)")
                        .IsRequired();

            builder.Property(v => v.GoogleMapsLink)
                        .HasColumnType("nvarchar(300)");

            builder.Property(v => v.MainContactPhone)
                        .HasColumnType("nvarchar(15)")
                        .IsRequired();

            builder.Property(v => v.HasEquipmentRental)
                        .HasColumnType("bit")
                        .HasDefaultValue(false);
                        

            // Relationships

            builder.HasMany(v => v.Courts) // One-to-Many relationship between Venue and Court  
                    .WithOne(c => c.Venue)
                    .HasForeignKey(c => c.VenueID)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.VenueWorkingHours) // One-to-Many relationship between Venue and VenueWorkingHours 
                    .WithOne(vwh => vwh.Venue)
                    .HasForeignKey(vwh => vwh.VenueID)
                    .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
