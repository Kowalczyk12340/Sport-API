using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class CoachConfiguration : IEntityTypeConfiguration<Coach>
  {
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
      builder.ToTable("Coach", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

      builder.Property(e => e.Name)
       .IsRequired()
       .HasMaxLength(100);

      builder.Property(e => e.Surname)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(e => e.Pesel)
        .IsRequired()
        .HasMaxLength(15);

      builder.Property(e => e.PhoneNumber)
      .IsRequired()
      .HasMaxLength(16);
    }
  }
}
