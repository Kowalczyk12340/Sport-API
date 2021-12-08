using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
  {
    public void Configure(EntityTypeBuilder<Department> builder)
    {
      builder.ToTable("Department", "Sport");

      builder.HasKey(e => e.DepartmentId);
      builder.Property(e => e.DepartmentId).HasDefaultValueSql("NEWID()");

      builder.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

      builder.Property(e => e.DepartmentName)
             .IsRequired()
             .HasMaxLength(200);

      builder.HasMany(d => d.Users).WithOne().HasForeignKey(d => d.InfomationId);
      builder.HasMany(d => d.Journalists).WithOne();
    }
  }
}
