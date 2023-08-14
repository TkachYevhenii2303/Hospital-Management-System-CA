using AutoMapper;
using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using Hospital_Management_System_Applications.Features.Employee.Commands.Insert_Employee;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Wrapper_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Commands.Create_Employee
{
    public record InsertEmployeeCommand : IRequest<Result<ReturnEmployeeDTO>>, IMappingFrom<Employees>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;
    }

    internal class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeeCommand, Result<ReturnEmployeeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsertEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReturnEmployeeDTO>> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employees employee = new Employees()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                Mobile = request.Mobile
            };

            await _unitOfWork.Repository<Employees>().InsertEntityAsync(employee);
            employee.AddDomainEvent(new InsertEmployeeEvent(employee));
            await _unitOfWork.Save(cancellationToken);
            return await Result<ReturnEmployeeDTO>.SuccessAsync(_mapper.Map<Employees, ReturnEmployeeDTO>(employee), 
                _unitOfWork.Repository<Employees>().InsertEntityAsync(employee).Result.Message);
        }
    }
}
