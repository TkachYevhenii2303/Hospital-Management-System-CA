using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Hospitals : AuditableEntity
    {
        public string HospitalTitle { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        public ICollection<Departments> Departments { get; set; } = null!;
    }
}
