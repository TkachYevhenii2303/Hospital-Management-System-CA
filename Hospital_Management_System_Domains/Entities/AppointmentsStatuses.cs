using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class AppointmentsStatuses : AuditableEntity
    {
        public string StatusTitle { get; set; } = string.Empty; 

        public ICollection<StatusHistories> StatusHistories { get; set; } = null!;
    }
}
