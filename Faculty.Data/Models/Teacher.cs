using System.Collections.Generic;
using Faculty.Data.Models;

namespace Faculty.Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

  
    }
}