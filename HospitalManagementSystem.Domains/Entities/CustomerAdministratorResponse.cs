using Hospital_Management_System_Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Domains.Entities
{
    public class CustomerAdministratorResponse : BaseAuditableEntity
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Password { get; set; }
        
        public string? Email { get; set; }
        
        public string? Token { get; set; }
    }
}
