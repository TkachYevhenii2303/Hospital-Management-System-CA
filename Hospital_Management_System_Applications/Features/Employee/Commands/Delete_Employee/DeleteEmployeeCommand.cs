using AutoMapper;
using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using Hospital_Management_System_Applications.Features.Employee.Commands.Update_Employee;
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

namespace Hospital_Management_System_Applications.Features.Employee.Commands.Delete_Employee
{
    public record DeleteEmployeeCommand : IRequest<Result<IEnumerable<ReturnEmployeeDTO>>>
    {
        public Guid ID { get; set; }

        public DeleteEmployeeCommand() { }

        public DeleteEmployeeCommand(Guid ID) { this.ID = ID; }
    }

    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result<IEnumerable<ReturnEmployeeDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ReturnEmployeeDTO>>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Repository<Employees>().ReturnEntityByIdAsync(request.ID);

            if (employee.Entity is not null)
            {
                var employees = await _unitOfWork.Repository<Employees>().DeleteEntityByIdAsync(request.ID);
                employee.Entity.AddDomainEvent(new DeleteEmployeeEvent(employee.Entity));

                await _unitOfWork.Save(cancellationToken);

                var result = _mapper.Map<IEnumerable<ReturnEmployeeDTO>>(employees.Entity);

                return await Result<IEnumerable<ReturnEmployeeDTO>>.SuccessAsync(result,
                    _unitOfWork.Repository<Employees>().DeleteEntityByIdAsync(request.ID).Result.Message);
            }
            else
            {
                throw new KeyNotFoundException($"The employee with {request.ID} ID not found! Check the all properties again please!");
            }
        }
    }
}
