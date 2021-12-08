using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class CategorySportConfiguration : IEntityTypeConfiguration<CategorySport>
  {
    public void Configure(EntityTypeBuilder<CategorySport> builder)
    {
      builder.ToTable("CategorySport", "Sport");

      builder.Property(e => e.CategorySportName)
                    .IsRequired()
                    .HasMaxLength(200);

      builder.HasKey(e => e.CategorySportId);
      builder.Property(e => e.CategorySportId).HasDefaultValueSql("NEWID()");
    }
  }
}
