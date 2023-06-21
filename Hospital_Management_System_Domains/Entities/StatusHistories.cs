using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class StatusHistories : AuditableEntity
    {
        public string Details { get; set; } = string.Empty;

        public Appointments Appointments { get; set; } = null!;

        public Guid AppointmentsId { get; set; }

        public AppointmentsStatuses AppointmentsStatus { get; set; } = null!;

        public Guid AppointmentStatusId { get; set; }
    }
}
