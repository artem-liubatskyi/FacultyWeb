using Faculty.Data.Models;
using Microsoft.EntityFrameworkCore;
using Faculty.Data.EntityConfigurations;
namespace Faculty.Data
{
    public class FacultyContext : DbContext
    {
        public FacultyContext(DbContextOptions<FacultyContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherSubjectConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}