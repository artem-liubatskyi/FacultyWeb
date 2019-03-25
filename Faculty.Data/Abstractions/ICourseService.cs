using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faculty.Data.Models;

namespace Faculty.Data
{
    public interface ICourseService
    {
        Task<Course> GetById(int id);
        Task<IReadOnlyCollection<Course>> GetAll();
        Task Create(Course course);
        Task Delete(int id);
        Task AddTeacher(int CourseID, Teacher teacher);
        Task AddSubject(int CourseID, Subject subject);
        Task DeleteTeacher(int CourseID, int TeacherID);
        Task DeleteSubject(int CourseID, int SubjectID);
    }
}
