using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faculty.Data;
using Faculty.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Faculty.Services
{
    public class CourseService : ICourseService
    {
        private readonly FacultyContext context;

        public CourseService(FacultyContext context)=>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public Task AddSubject(int CourseID, Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task AddTeacher(int CourseID, Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubject(int CourseID, int SubjectID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacher(int CourseID, int TeacherID)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Course>> GetAll()=>
            await context.Courses.Include(c=>c.Subjects).ToListAsync();

        public Task<Course> GetById(int id)
        {
            return context.Courses.Where(x => x.Id == id)
                .Include(x => x.Subjects)
                .ThenInclude(x => x.TeacherSubjects)
                .ThenInclude(x => x.Teacher)
                .Include(x =>x.Speciality)
                .FirstOrDefaultAsync();
        }
    }
}
