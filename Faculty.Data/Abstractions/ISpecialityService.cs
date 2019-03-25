using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Faculty.Data.Models;

namespace Faculty.Data
{
    public interface ISpecialityService
    {
        Task<Speciality> GetById(int Id);
        Task<IReadOnlyCollection<Speciality>> GetAll();
        Task AddSpeciality(Speciality speciality);
        Task DeleteSpeciality(int SpecialityID);
        Task AddCourse(int SpecialityID, Course course);
        Task DeleteCourse(int SpesialityID, int CourseID);
    }
}
