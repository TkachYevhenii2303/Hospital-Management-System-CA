using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Departments : AuditableEntity
    {
        public string DepartmentTitle { get; set; } = string.Empty;

        public Hospitals Hospital { get; set; } = null!;

        public Guid HospitalId { get; set; }

        public ICollection<InDepartments> InDepartments { get; set; } = null!;
    }
}
