using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class User : IUser
    {
        public User(string name, byte age, string password, string status)
        {
            Name = name;
            Age = age;
            Password = password;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; set ; }
        public byte Age { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string EmailAdress { get; set; }
    }
       
}
