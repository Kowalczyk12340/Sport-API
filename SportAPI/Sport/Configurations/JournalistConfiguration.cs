using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
  {
    public void Configure(EntityTypeBuilder<Journalist> builder)
    {
      builder.ToTable("Journalist","Sport");

      builder.HasKey(e => e.JournalistId);
      builder.Property(e => e.JournalistId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(200);

      builder.Property(e => e.Position)
       .IsRequired()
       .HasMaxLength(200);

      builder.Property(e => e.Surname)
       .IsRequired()
       .HasMaxLength(200);

      builder.Property(e => e.Seniority)
       .IsRequired()
       .HasMaxLength(200);

      builder.HasOne(d => d.EmailAddress);
      builder.HasOne(d => d.PhoneNumber);
    }

  }
}