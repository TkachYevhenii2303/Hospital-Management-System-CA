using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Patients : AuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public ICollection<Documents> Documents { get; set; } = null!;

        public ICollection<PatientsCases> PatientsCases { get; set; } = null!;
    }
}
