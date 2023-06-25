using AutoMapper;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Wrapper_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_Specialization
{
    public record EmployeeSpecializationQuery : IRequest<Result<IEnumerable<ReturnEmployeeSpecializationDTO>>>
    {
        public string Specialization { get; set; }

        public EmployeeSpecializationQuery() { }

        public EmployeeSpecializationQuery(string specialization) => Specialization = specialization;
    }

    internal class EmployeeSpecializationQueryHandler :
        IRequestHandler<EmployeeSpecializationQuery, Result<IEnumerable<ReturnEmployeeSpecializationDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeSpecializationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<IEnumerable<ReturnEmployeeSpecializationDTO>>> Handle(EmployeeSpecializationQuery request, 
            CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.ReturnEmployeeBySpecialization(request.Specialization);
            var result = _mapper.Map<IEnumerable<ReturnEmployeeSpecializationDTO>>(employees);
        }
    }
}
