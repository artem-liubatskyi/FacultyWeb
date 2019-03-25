using System.Collections.Generic;

namespace Faculty.Data.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}