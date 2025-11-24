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
    internal class VenueWorkingHoursConfiguration : IEntityTypeConfiguration<VenueWorkingHours>
    {
        public void Configure(EntityTypeBuilder<VenueWorkingHours> builder)
        {
            builder.HasKey(vwh => vwh.VenueWorkingHoursID);

            builder.Property(vwh => vwh.DayOfWeek)
                    .HasConversion<string>()
                    .HasMaxLength(15)
                   .IsRequired();

            builder.Property(vwh => vwh.OpenTime)
                    .HasColumnType("time")
                    .IsRequired();

            builder.Property(vwh => vwh.CloseTime)
                    .HasColumnType("time")
                    .IsRequired();
        }
    }
}
