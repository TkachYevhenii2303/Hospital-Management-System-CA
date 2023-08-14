using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Enums;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IGenericRepository<Employees> _repository;
        private readonly HospitalManagementContext _context;

        public EmployeeRepository(IGenericRepository<Employees> repository, HospitalManagementContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Result<IEnumerable<Employees>>> ReturnEmployeeBySpecialization(string specialization)
        {
            var result = new Result<IEnumerable<Employees>>();

            result.Entity = await _context.Set<Employees>()
                .Where(x => x.HasRoles.Any(x => x.Roles.RolesTitle == specialization))
                .Include(x => x.HasRoles).ThenInclude(x => x.Roles)
                .AsNoTracking().ToListAsync();

            result.Message = $"Employee Retrieval by Specialization: " +
                $"Congratulations on implementing the method {ReturnEmployeeBySpecialization(specialization).GetType().Name}";

            return result;
        }
    }
}
