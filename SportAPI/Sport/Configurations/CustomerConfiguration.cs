using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.ToTable("Customer", "Sport");

      builder.HasKey(e => e.CustomerId);
      builder.Property(e => e.CustomerId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

      builder.Property(e => e.Name)
             .IsRequired()
             .HasMaxLength(200);

      builder.HasOne(d => d.EmailAddress);
      builder.HasOne(d => d.PhoneNumber);
      builder.HasOne(d => d.Pesel);
    }
  }
}
