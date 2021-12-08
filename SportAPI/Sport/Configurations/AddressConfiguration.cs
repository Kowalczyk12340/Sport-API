using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class AddressConfiguration : IEntityTypeConfiguration<Address>
  {
    public void Configure(EntityTypeBuilder<Address> builder)
    {
      builder.ToTable("Address", "Sport");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.City)
        .IsRequired().
        HasMaxLength(100);

      builder.Property(e => e.Street)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(e => e.PostalCode)
        .IsRequired()
        .HasMaxLength(100);
    }
  }
}
