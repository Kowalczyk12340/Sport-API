using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportAPI.Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPI.Sport.Configurations
{
  public class CoachCourseConfiguration : IEntityTypeConfiguration<CoachCourse>
  {
    public void Configure(EntityTypeBuilder<CoachCourse> builder)
    {
      builder.ToTable("CoachCourse", "Sport");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();

      builder.HasOne(b => b.Coach)
        .WithMany(x => x.CoachCourses)
        .HasForeignKey(y => y.CoachId);

      builder.HasOne(b => b.Course)
        .WithMany(x => x.CoachCourses)
        .HasForeignKey(y => y.CourseId);
    }
  }
}
