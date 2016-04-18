using System;

namespace MyJoints.ViewModel.Users
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
