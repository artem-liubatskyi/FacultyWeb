using System.Collections.Generic;
using Faculty.Data.Models;

namespace Faculty.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}