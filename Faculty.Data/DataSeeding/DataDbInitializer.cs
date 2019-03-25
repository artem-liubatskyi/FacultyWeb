using System;
using System.Collections.Generic;
using System.Linq;
using Faculty.Data.Authentication_Models;
using Faculty.Data.Models;

namespace Faculty.Data.DataSeeding
{
    public static class DataDbInitializer
    {
        public static void AuthSeed(AuthenticationContext context)
        {
            if(!context.Roles.Any())
            {
                var roles = new List<Role>()
                {
                    new Role(){ Name="user"},
                    new Role(){ Name="admin"},
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
        }
        public static void Seed(FacultyContext context)
        {
            if (!context.Specialities.Any())
            {
                var speciality = new List<Speciality>()
                {
                    new Speciality(){Name = "Computer Engeneering"},
                    new Speciality(){Name = "Computer Securuty"},
                };
                context.Specialities.AddRange(speciality);
            }
            if (!context.Courses.Any())
            {
                var CE = context.Specialities.FirstOrDefault(s => s.Name == "Computer Engeneering");
                var CS = context.Specialities.FirstOrDefault(s => s.Name == "Computer Securuty");
                var courses = new List<Course>()
                {
                    new Course(){Name = "CE-16-1",SpecialityId=CE.Id},
                    new Course(){Name = "CS-16-1", SpecialityId=CS.Id},
                };
                context.Courses.AddRange(courses);
            }
            if (!context.Subjects.Any())
            {
                var CE = context.Courses.FirstOrDefault(s => s.Name == "CE-16-1");
                var CS = context.Courses.FirstOrDefault(s => s.Name == "CS-16-1");
                var subjects = new List<Subject>()
                {
                    new Subject(){Name = "System Modeling", Hours = 24, CourseId = CE.Id},
                    new Subject(){Name = "System Programming", Hours = 14, CourseId = CE.Id},
                    new Subject(){Name = "Cryptosystems", Hours = 24, CourseId = CS.Id},
                    new Subject(){Name = "Mobile Systems Security", Hours = 24, CourseId = CS.Id},
                };
                context.Subjects.AddRange(subjects);
            }
            if (!context.Teachers.Any())
            {
                var teachers = new List<Teacher>()
                {
                    new Teacher(){FullName="Gorbachev V. A."},
                    new Teacher(){FullName="Volk M. O."},
                    new Teacher(){FullName="Borzenko N. P."},
                    new Teacher(){FullName="Borzenko N. P."},
                };
                context.Teachers.AddRange(teachers);
            }

            if(!context.Teachers.Any() &&!context.Subjects.Any())
                context.SaveChanges();

            if (!context.TeacherSubjects.Any())
            {
                var SystemModeling = context.Subjects.FirstOrDefault(s => s.Name == "System Modeling");
                var SystemProgramming = context.Subjects.FirstOrDefault(s => s.Name == "System Programming");
                var Cryptosystems = context.Subjects.FirstOrDefault(s => s.Name == "Cryptosystems");
                var MobileSystemsSecurity = context.Subjects.FirstOrDefault(s => s.Name == "Mobile Systems Security");

                var Gorbachev = context.Teachers.FirstOrDefault(t => t.FullName == "Gorbachev V. A.");
                var Volk = context.Teachers.FirstOrDefault(t => t.FullName == "Volk M. O.");
                var Borzenko = context.Teachers.FirstOrDefault(t => t.FullName == "Borzenko N. P.");

                var teacherSubjects = new List<TeacherSubject>()
                {
                    new TeacherSubject(){SubjectId = SystemProgramming.Id, TeacherId = Volk.Id},
                    new TeacherSubject(){SubjectId = Cryptosystems.Id, TeacherId = Borzenko.Id},
                    new TeacherSubject(){SubjectId = SystemModeling.Id, TeacherId = Gorbachev.Id},
                    new TeacherSubject(){SubjectId = MobileSystemsSecurity.Id, TeacherId = Borzenko.Id},
                };
                context.TeacherSubjects.AddRange(teacherSubjects);
            }
            context.SaveChanges();
        }
    }
}
