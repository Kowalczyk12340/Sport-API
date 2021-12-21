using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class TrainingConfiguration : IEntityTypeConfiguration<Training>
  {
    public void Configure(EntityTypeBuilder<Training> builder)
    {
      builder.ToTable("Training", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(120);

      builder.Property(e => e.TimeOfTraining)
        .IsRequired()
        .HasColumnType("DateTime");
    }
  }
}
