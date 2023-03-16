using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    internal class User
    {
   
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public char Gender { get; set; }
        public bool HasChild { get; set; }
        public bool HasParent { get; set; }
    }
}
