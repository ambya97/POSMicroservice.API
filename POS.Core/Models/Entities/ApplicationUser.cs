using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Entities
{
    public class ApplicationUser
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public  string? SecurityStamp { get; set; }
        public  string? PasswordHash { get; set; }
        public  bool EmailConfirmed { get; set; }
    }
}
