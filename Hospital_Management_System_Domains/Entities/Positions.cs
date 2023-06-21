using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Positions : AuditableEntity
    {
        public string RolesTitle { get; set; } = string.Empty;

        public ICollection<HasRoles> HasRoles { get; set; } = null!;
    }
}
