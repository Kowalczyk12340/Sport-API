using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class SportSportsmanConfiguration : IEntityTypeConfiguration<SportSportsman>
  {
    public void Configure(EntityTypeBuilder<SportSportsman> builder)
    {
      builder.ToTable("SportSportsman", "Sport");

      builder.HasKey(e => e.SportSportsmanId);
      builder.Property(e => e.SportSportsmanId).HasDefaultValueSql("NEWID()");

      builder.HasMany(d => d.Sports)
      .WithOne()
      .HasForeignKey(d => d.SportId)
      .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_SportSportsman_Sport");

      builder.HasMany(d => d.Sportsmans)
        .WithOne()
        .HasForeignKey(d => d.SportsmanId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_SportSportsman_Sportsman");

      builder.Property(e => e.Amount)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
    }

  }
}