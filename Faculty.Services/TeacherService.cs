using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Faculty.Data;
using Faculty.Data.Models;

namespace Faculty.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly FacultyContext context;

        public TeacherService(FacultyContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public Task AddSubject(int TeacherID, Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task Create(Teacher teacher)
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

        public async Task<IReadOnlyCollection<Teacher>> GetAll()
        {
            return await context.Teachers
                .Include(x=>x.TeacherSubjects)
                .ThenInclude(x=>x.Subject)
                .ToListAsync();
        }

        public Task<Teacher> GetById(int? id)
        {
            return context.Teachers
                .Where(x => x.Id == id)
                .Include(x => x.TeacherSubjects)
                .ThenInclude(x => x.Subject)
                .FirstOrDefaultAsync();
        }
    }
}
