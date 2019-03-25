using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faculty.Data.Models;

namespace Faculty.Data
{
    public interface ITeacherService
    {
        Task<Teacher> GetById(int? id);
        Task<IReadOnlyCollection<Teacher>> GetAll();
        Task Create(Teacher teacher);
        Task Delete(int id);
        Task AddSubject(int TeacherID, Subject subject);
        Task DeleteSubject(int TeacherID, int SubjectID);
    }
}
