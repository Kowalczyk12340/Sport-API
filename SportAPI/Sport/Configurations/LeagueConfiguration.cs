using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class LeagueConfiguration : IEntityTypeConfiguration<League>
  {
    public void Configure(EntityTypeBuilder<League> builder)
    {
      builder.ToTable("League", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(140);

      builder.Property(e => e.CountForChampionsLeague)
        .IsRequired().HasColumnType("int");

      builder.Property(e => e.CountForEuropeLeague)
        .IsRequired().HasColumnType("int");
      
      builder.Property(e => e.CountForConferenceLeague)
        .IsRequired().HasColumnType("int");

      builder.Property(e => e.CountForDownLeague)
        .IsRequired().HasColumnType("int");

      builder.Property(e => e.IsHigh)
      .IsRequired()
      .HasDefaultValueSql("'1'");
    }
  }
}
