using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class PatientsCases : AuditableEntity
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal TotalCost { get; set; } = decimal.Zero;

        public Patients Patients { get; set; } = null!;

        public Guid PatientsId { get; set; }

        public ICollection<Documents> Documents { get; set; } = null!;

        public ICollection<Appointments> Appointments { get; set; } = null!;
    }
}
