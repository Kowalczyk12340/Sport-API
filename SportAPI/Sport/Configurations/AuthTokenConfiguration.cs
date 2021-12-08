using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SportAPI.Sport.Models;

namespace SportAPI.Sport.Configurations
{
  public class AuthTokenConfiguration : IEntityTypeConfiguration<AuthToken>
  {
    public void Configure(EntityTypeBuilder<AuthToken> builder)
    {
      builder.ToTable("AuthToken", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
      builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    }
  }
}