using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class StatusInformationConfiguration : IEntityTypeConfiguration<StatusInformation>
  {
    public void Configure(EntityTypeBuilder<StatusInformation> builder)
    {
      builder.ToTable("StatusInformation","Sport");

      builder.HasKey(e => e.StatusInformationId);
      builder.Property(e => e.StatusInformationId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.StatusInformationName)
                    .IsRequired()
                    .HasMaxLength(200);
    }
  }
}