using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class SportDisciplineConfiguration : IEntityTypeConfiguration<SportDiscipline>
  {
    public void Configure(EntityTypeBuilder<SportDiscipline> builder)
    {
      builder.ToTable("SportDiscipline", "Sport");

      builder.HasKey(e => e.SportId);
      builder.Property(e => e.SportId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.SportName)
             .IsRequired()
             .HasMaxLength(300);

      builder.HasMany(d => d.Sportsmans)
        .WithOne()
        .HasForeignKey(d => d.SportsmanId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Sport_Sportsman");

      builder.HasOne(d => d.Description);
      builder.HasMany(d => d.Sportsmans);
    }

  }
}
