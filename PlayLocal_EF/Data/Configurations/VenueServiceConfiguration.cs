using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayLocal_EF.Entities;

namespace PlayLocal_EF.Data.Configurations
{
    internal class VenueServiceConfiguration : IEntityTypeConfiguration<VenueService>
    {
        public void Configure(EntityTypeBuilder<VenueService> builder)
        {
            builder.HasKey(vs => vs.ServiceID); // primary key

            builder.Property(vs => vs.ServiceType)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)")
                   .HasMaxLength(100);

            builder.Property(vs => vs.ItemName)
                     .IsRequired()
                     .HasColumnType("nvarchar(200)")
                     .HasMaxLength(200);

            builder.Property(vs => vs.Price)
                     .IsRequired()
                     .HasColumnType("money");


        }
    }
}
