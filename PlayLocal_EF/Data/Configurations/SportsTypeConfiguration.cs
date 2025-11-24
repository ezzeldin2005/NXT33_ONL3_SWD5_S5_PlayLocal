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
    internal class SportsTypeConfiguration : IEntityTypeConfiguration<SportsType>
    {
        public void Configure(EntityTypeBuilder<SportsType> builder)
        {
            builder.HasKey(st => st.SportId); // primary key


            builder.Property(st => st.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)")
                   .HasMaxLength(100);
        }
    }
}
