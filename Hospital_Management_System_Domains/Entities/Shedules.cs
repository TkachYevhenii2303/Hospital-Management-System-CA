using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class Shedules : BaseAuditableEntity
    {
        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public InDepartments InDepartment { get; set; } = null!; 

        public Guid InDepartmentsId { get; set; }
    }
}
