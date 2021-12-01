using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
   public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
