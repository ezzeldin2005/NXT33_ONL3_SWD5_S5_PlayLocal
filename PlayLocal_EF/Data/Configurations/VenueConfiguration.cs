using Microsoft.EntityFrameworkCore;
using PlayLocal_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Data.Configurations
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
                        

            builder.Property(v => v.OpenTime)
                        .HasColumnType("Time")
                        .IsRequired();

            builder.Property(v => v.CloseTime)
                        .HasColumnType("Time")
                        .IsRequired();

            builder.Property(v => v.CloseDay)
                        .HasColumnType("nvarchar(20)")
                        .IsRequired();

            // Relationships

            builder.HasMany(v => v.Courts) // One-to-Many relationship between Venue and Court  
                    .WithOne(c => c.Venue)
                    .HasForeignKey(c => c.VenueID)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(v => v.VenueServices) // One-to-Many relationship between Venue and VenueService
                    .WithOne(vs => vs.Venue)
                    .HasForeignKey(vs => vs.VenueID)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
