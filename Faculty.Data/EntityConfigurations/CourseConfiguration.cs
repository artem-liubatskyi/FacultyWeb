using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Faculty.Data.Models;

namespace Faculty.Data.EntityConfigurations
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasOne(x => x.Speciality)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.SpecialityId);
        }
    }
}
