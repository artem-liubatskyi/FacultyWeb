using System;
using System.Collections.Generic;
using System.Text;

namespace Faculty.Data.Authentication_Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
