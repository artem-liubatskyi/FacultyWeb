using Faculty.Data;
using Faculty.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Faculty.Data.DataSeeding;

namespace Faculty.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly FacultyContext context;

        public SubjectService(FacultyContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task AddTeacher(int TeacherID, Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task Create(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubject(int TeacherID, int SubjectID)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyCollection<Subject>> GetAll()
        {
            return await context.Subjects.Include(s => s.TeacherSubjects)
                    .ThenInclude(x => x.Teacher)
                    .Include(x => x.Course)
                    .ToListAsync();
        }

        public Task<Subject> GetById(int? id)
        {
            return context.Subjects.Where(x => x.Id == id)
                .Include(x => x.TeacherSubjects)
                .ThenInclude(x=>x.Teacher)
                .Include(x=>x.Course)
                .FirstOrDefaultAsync();
        }
    }
}