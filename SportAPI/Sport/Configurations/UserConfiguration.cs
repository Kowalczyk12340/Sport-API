using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("User","Sport");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Login)
              .HasMaxLength(32)
              .IsRequired();

      builder.Property(e => e.Password)
        .HasMaxLength(32)
        .IsRequired();

      builder.Property(e => e.FirstName)
          .IsRequired()
          .HasMaxLength(120);

      builder.Property(e => e.LastName)
          .IsRequired()
          .HasMaxLength(120);

      builder.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
    }
  }
}
