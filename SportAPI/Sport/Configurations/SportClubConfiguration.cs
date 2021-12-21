using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class SportClubConfiguration : IEntityTypeConfiguration<SportClub>
  {
    public void Configure(EntityTypeBuilder<SportClub> builder)
    {
      builder.ToTable("SportClub", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.Property(e => e.SportClubName)
        .IsRequired()
        .HasMaxLength(140);

      builder.Property(e => e.Category)
        .IsRequired()
        .HasMaxLength(80);

      builder.Property(e => e.ContactEmail)
        .IsRequired()
        .HasMaxLength(120);

      builder.Property(e => e.ContactNumber)
      .IsRequired()
      .HasMaxLength(16);

      builder.Property(e => e.HasOwnStadium)
      .IsRequired()
      .HasDefaultValueSql("'1'");
    }
  }
}
