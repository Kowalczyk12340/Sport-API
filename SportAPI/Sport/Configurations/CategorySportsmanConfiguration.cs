using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class CategorySportsmanConfiguration : IEntityTypeConfiguration<CategorySportsman>
  {
    public void Configure(EntityTypeBuilder<CategorySportsman> builder)
    {
      builder.ToTable("CategorySportsman", "Sport");

      builder.Property(e => e.CategorySportsmanName)
                    .IsRequired()
                    .HasMaxLength(200);

      builder.HasKey(e => e.CategorySportsmanId);
      builder.Property(e => e.CategorySportsmanId).HasDefaultValueSql("NEWID()");
    }
  }
}
