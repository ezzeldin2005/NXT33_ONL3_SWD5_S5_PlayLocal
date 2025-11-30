using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Configurations
{
    internal class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Court> builder)
        {
           builder.HasKey(c => c.CourtID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder.Property(c => c.PricePerHour)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(c => c.Is_Available)
                .HasDefaultValue(true)
                .HasColumnType("bit");

            builder.Property(c => c.Environment)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.Surface)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(c => c.Size)
                .HasColumnType("int");
            

            // Relationships

            builder.HasMany(c => c.CourtPhotos) // One-to-Many relationship between Court and CourtPhoto
                   .WithOne(cp => cp.Court)
                   .HasForeignKey(cp => cp.CourtID)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(c => c.SportsTypes) // Many-to-Many relationship between Court and SportsType
               .WithMany(s => s.Courts)
               .UsingEntity(j => j.ToTable("CourtSports"));

        }
    }
}
