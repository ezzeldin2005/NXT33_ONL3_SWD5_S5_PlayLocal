using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayLocal_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayLocal_EF.Data.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.BookingID);

            builder.Property(b => b.BookingDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(b => b.StartTime)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(b => b.EndTime)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(b => b.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.Rating)
                .HasColumnType("float");

            builder.Property(b => b.AmountPaid)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(b => b.PaymentMethod)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.PaymentStatus)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            // Relationships

            builder.HasOne(b => b.Player) // Navigation Property للاعب
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PlayerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Court) // Navigation Property للملعب
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CourtID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
