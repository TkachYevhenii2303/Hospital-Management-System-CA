using Hospital_Management_System_Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Infrastructure.Services
{
    public class CustomerAdministratorService : ICustomerAdministratorService
    {
        private readonly HospitalManagementContext _context;

        public CustomerAdministratorService(HospitalManagementContext context)
        {
            _context = context;
        }
    }
}
