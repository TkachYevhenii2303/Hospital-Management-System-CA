using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Appointments : BaseAuditableEntity
    {
        public DateTime AppointmentStartTime { get; set; }

        public DateTime AppointmentEndTtime { get; set; }

        public PatientsCases PatientsCases { get; set; } = null!;

        public Guid PatientCasesId { get; set; }

        public InDepartments InDepartment { get; set; } = null!;

        public Guid InDepartmentsId { get; set; }

        public ICollection<StatusHistories> StatusHistories { get; set; } = null!;
    }
}
