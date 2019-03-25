using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Faculty.Data;
using Faculty.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Faculty.Data.DataSeeding;

namespace Faculty.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly FacultyContext context;

        public SpecialityService(FacultyContext context) =>
            this.context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task AddCourse(int SpecialityID, Course course)
        {
            if (course == null)
                throw new NullReferenceException("Null referense course");

            var speciality = context.Specialities.FirstOrDefault(s => s.Id == SpecialityID);

            if (speciality == null)
                throw new NullReferenceException("Null referense course");

            speciality.Courses.Add(course);
            await context.SaveChangesAsync();
        }

        public async Task AddSpeciality(Speciality speciality)
        {
            if (speciality == null)
                throw new NullReferenceException("Null referense speciality");

            if (context.Specialities.Contains(speciality))
                throw new Exception("Speciality already exist");

            context.Specialities.Add(speciality);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int SpecialityID, int CourseID)
        {
            var spesiality = context.Specialities.FirstOrDefault(s => s.Id == SpecialityID);

            if (spesiality == null)
                throw new Exception("No such speciality");

            var course = context.Courses.FirstOrDefault(c => c.Id == CourseID);

            if (course == null)
                throw new Exception("No such course");

            spesiality.Courses.Remove(course);
            await context.SaveChangesAsync();

        }

        public async Task DeleteSpeciality(int SpecialityID)
        {
            var speciality = context.Specialities.FirstOrDefault(s => s.Id == SpecialityID);

            if (speciality == null)
                throw new Exception("No such speciality");

            context.Specialities.Remove(speciality);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Speciality>> GetAll() =>
            await context.Specialities.Include(s => s.Courses).ToListAsync();

        public Task<Speciality> GetById(int Id)
        {
            return context.Specialities
                .Where(x => x.Id == Id)
                .Include(x => x.Courses)
                .FirstOrDefaultAsync();
        }
    }
}