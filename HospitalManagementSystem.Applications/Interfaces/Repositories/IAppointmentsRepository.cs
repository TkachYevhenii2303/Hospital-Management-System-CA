using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Wrapper_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Interfaces.Repositories
{
    public interface IAppointmentsRepository
    {
        Task<Result<IEnumerable<Appointments>>> ReturnAppointmentsAsync();
    }
}
