using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.PlayLocal.Configurations
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.OwnerID); // primary key

      

            builder.Property(o => o.FullName)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)")
                   .HasMaxLength(100);

            builder.Property(o => o.Email)
                     .IsRequired()
                     .HasColumnType("nvarchar(100)")
                     .HasMaxLength(100);

            builder.Property(o => o.PhoneNumber)
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

            builder.Property(o => o.Password)
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);
            // Relationships

            builder.HasMany(o => o.Venues) // One-to-Many relationship between Owner and Venue
                   .WithOne(v => v.Owner)
                   .HasForeignKey(v => v.OwnerID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
