using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using SportAPI.Sport.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class SportsmanConfiguration : IEntityTypeConfiguration<Sportsman>
  {
    public void Configure(EntityTypeBuilder<Sportsman> builder)
    {
      builder.ToTable("Sportsman","Sport");

      builder.HasKey(e => e.SportsmanId);
      builder.Property(e => e.SportsmanId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.Foot)
                    .IsRequired()
                    .HasDefaultValue(BetterFoot.RIGHT);

      builder.HasMany(d => d.Sports)
      .WithOne()
      .HasForeignKey(d => d.SportId)
      .OnDelete(DeleteBehavior.ClientSetNull)
      .HasConstraintName("FK_Sportsman_Sport");

      builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(e => e.Surname)
       .IsRequired()
       .HasMaxLength(200);

      builder.HasOne(d => d.Pesel);
      builder.HasMany(d => d.Sports);
    }

  }
}
