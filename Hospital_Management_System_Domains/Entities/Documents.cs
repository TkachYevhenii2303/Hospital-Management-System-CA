using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Documents : AuditableEntity
    {
        public string DocumentsTitle { get; set; } = string.Empty;

        public string DocumentsLink { get; set; } = string.Empty;

        public string DocumentsDetails { get; set; } = string.Empty;

        public DocumentsTypes DocumentsTypes { get; set; } = null!;

        public Guid DocumentsTypesId { get; set; }

        public Patients Patients { get; set; } = null!;

        public Guid PatientsId { get; set; }

        public PatientsCases PatientsCases { get; set; } = null!;

        public Guid PatientCaseId { get; set; }

        public InDepartments InDepartment { get; set; } = null!;

        public Guid InDepartmentId { get; set; }

        public Appointments Appointments { get; set; } = null!;

        public Guid AppointmentsId { get; set; }
    }
}
