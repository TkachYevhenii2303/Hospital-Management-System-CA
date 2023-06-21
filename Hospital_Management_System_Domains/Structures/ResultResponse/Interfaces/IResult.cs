using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Domains.Structures.WrapperResponse.Interfaces
{
    public interface IResult<TEntity>
    {
        TEntity Entity { get; set; }

        string Message { get; set; }
        
        bool Succeeded { get; set; }

        Exception Exception { get; set; }

        int StatusCode { get; set; }
    }
}
