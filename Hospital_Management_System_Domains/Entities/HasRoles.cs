using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class HasRoles : AuditableEntity
    {
        public Employees Employees { get; set; } = default!;

        public Guid EmployeesId { get; set; }

        public Positions Roles { get; set; } = null!;

        public Guid RolesId { get; set; }
    }
}
