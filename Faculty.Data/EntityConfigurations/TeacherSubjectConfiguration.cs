using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Faculty.Data.Models;

namespace Faculty.Data.EntityConfigurations
{
    class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.ToTable("TeacherSubjects");

            builder.HasKey(x => new { x.TeacherId, x.SubjectId });

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherSubjects)
                .HasForeignKey(x => x.TeacherId);

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.TeacherSubjects)
                .HasForeignKey(x => x.SubjectId);
        }
    }
}
