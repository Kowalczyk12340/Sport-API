using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class InformationConfiguration : IEntityTypeConfiguration<Information>
  {
    public void Configure(EntityTypeBuilder<Information> builder)
    {
      builder.ToTable("Information","Sport");

      builder.HasKey(e => e.InformationId);
      builder.Property(e => e.InformationId).HasDefaultValueSql("NEWID()");

      builder.HasOne(d => d.Journalist)
          .WithMany()
          .HasForeignKey(d => d.JournalistId)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Information_Journalist");

      builder.HasOne(d => d.Customer)
        .WithMany()
        .HasForeignKey(d => d.CustomerId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Information_Customer");

      builder.Property(e => e.Title)
                    .IsRequired();

      builder.Property(e => e.Info)
             .IsRequired()
             .HasMaxLength(400);

      builder.HasMany(d => d.Disciplines);
      builder.HasOne(d => d.DateOfInfo);
    }

  }
}
