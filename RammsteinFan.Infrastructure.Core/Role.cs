using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Role : IRole
    {
        public Role()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
