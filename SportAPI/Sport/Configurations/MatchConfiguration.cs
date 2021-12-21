using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class MatchConfiguration : IEntityTypeConfiguration<Match>
  {
    public void Configure(EntityTypeBuilder<Match> builder)
    {
      builder.ToTable("Match", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.Property(e => e.InHouse)
        .IsRequired()
        .HasDefaultValueSql("'1'");

      builder.Property(e => e.TeamOne)
        .IsRequired()
        .HasMaxLength(140);

      builder.Property(e => e.TeamTwo)
      .IsRequired()
      .HasMaxLength(140);

      builder.Property(e => e.DateOfMatch)
        .IsRequired()
        .HasColumnType("DateTime");
    }
  }
}
