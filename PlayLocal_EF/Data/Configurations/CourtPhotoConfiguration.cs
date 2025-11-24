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
    internal class CourtPhotoConfiguration : IEntityTypeConfiguration<CourtPhoto>
    {
        public void Configure(EntityTypeBuilder<CourtPhoto> builder)
        {
            builder.HasKey(cp => cp.PhotoID); // primary key

            builder.Property(cp => cp.Image)
                   .IsRequired()
                   .HasColumnType("nvarchar(200)")
                   .HasMaxLength(200);


        }
    }
}
