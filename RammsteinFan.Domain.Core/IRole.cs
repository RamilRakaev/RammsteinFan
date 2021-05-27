using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
