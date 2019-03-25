using System.Collections.Generic;

namespace Faculty.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}