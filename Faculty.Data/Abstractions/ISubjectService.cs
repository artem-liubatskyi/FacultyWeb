using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faculty.Data.Models;

namespace Faculty.Data
{
    public interface ISubjectService
    {
        Task<Subject> GetById(int? id);
        Task<IReadOnlyCollection<Subject>> GetAll();
        Task Create(Subject subject);
        Task Delete(int id);
        Task AddTeacher(int TeacherID, Teacher teacher);
        Task DeleteSubject(int TeacherID, int SubjectID);
    }
}
