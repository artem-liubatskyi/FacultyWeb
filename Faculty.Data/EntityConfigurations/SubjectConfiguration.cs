using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Faculty.Data.Models;

namespace Faculty.Data.EntityConfigurations
{
    class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasOne(x =>x.Course)
                .WithMany(x=>x.Subjects)
                .HasForeignKey(x => x.CourseId);
        }
    }
}
