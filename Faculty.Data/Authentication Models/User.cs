using System;
using System.Collections.Generic;
using System.Text;

namespace Faculty.Data.Authentication_Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
