using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class AppUser
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
