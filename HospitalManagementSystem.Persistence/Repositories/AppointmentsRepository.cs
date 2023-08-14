using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Repositories
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly IGenericRepository<Appointments> _repository;
        private readonly HospitalManagementContext _context;

        public AppointmentsRepository(IGenericRepository<Appointments> repository, HospitalManagementContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Result<IEnumerable<Appointments>>> ReturnAppointmentsAsync()
        {
            var result = new Result<IEnumerable<Appointments>>();

            result.Entity = await _context.Set<Appointments>()
                .Include(a => a.InDepartment.Employees) 
                .Include(a => a.PatientsCases.Patients) 
                .AsNoTracking().ToListAsync();

            result.Message = $"Appointments retrieval: Congratulations on implementing the method {nameof(ReturnAppointmentsAsync)}";

            return result;
        }
    }
}
