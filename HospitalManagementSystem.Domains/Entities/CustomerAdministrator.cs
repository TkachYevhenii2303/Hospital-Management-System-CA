using Hospital_Management_System_Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Domains.Entities
{
    public class CustomerAdministrator : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = false;
    }
}
