using DAL.PlayLocal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PlayLocal.Configurations
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PlayerID);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .HasMaxLength(200);

            builder.Property(p => p.passwordHash)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.PhoneNumber)
                .HasColumnType("nvarchar(15)");
    

            builder.Property(p => p.ProfilePictureUrl)
                .HasMaxLength(200);

           builder.Property(p => p.Hobby)
                .HasMaxLength(100);


        }
    }
}
