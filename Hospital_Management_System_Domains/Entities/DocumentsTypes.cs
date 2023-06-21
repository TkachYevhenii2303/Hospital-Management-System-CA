using Hospital_Management_System_Domains.Common;

namespace Hospital_Management_System_DAL.Entities
{
    public class DocumentsTypes : BaseAuditableEntity
    {
        public string TypesTitle { get; set; } = string.Empty;

        public ICollection<Documents> Documents { get; set; } = null!;
    }
}
