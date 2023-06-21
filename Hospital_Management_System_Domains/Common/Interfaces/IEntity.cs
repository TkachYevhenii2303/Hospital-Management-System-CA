using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Domains.Common.Interfaces
{
    public interface IEntity
    {
        Guid ID { get; set; }
    }
}
