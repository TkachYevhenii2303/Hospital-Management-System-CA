using AutoMapper;
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

namespace Hospital_Management_System_Applications.Features.Employee.Commands.Update_Employee
{
    public record UpdateEmployeeCommand : IRequest<Result<ReturnEmployeeDTO>>
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;
    }

    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<ReturnEmployeeDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReturnEmployeeDTO>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Repository<Employees>().ReturnEntityByIdAsync(request.ID);

            if (employee is not null) 
            { 
                employee.Entity.FirstName = request.FirstName;
                employee.Entity.LastName = request.LastName;
                employee.Entity.Email = request.Email;
                employee.Entity.Mobile = request.Mobile;

                await _unitOfWork.Repository<Employees>().UpdateEntityAsync(employee.Entity);
                employee.Entity.AddDomainEvent(new UpdateEmployeeEvent(employee.Entity));

                var result = _mapper.Map<ReturnEmployeeDTO>(employee.Entity);

                await _unitOfWork.Save(cancellationToken);
                return await Result<ReturnEmployeeDTO>.SuccessAsync(result,
                    _unitOfWork.Repository<Employees>().UpdateEntityAsync(employee.Entity).Result.Message);
            }
            else
            {
                throw new KeyNotFoundException($"The employee with {request.ID} ID not found! Check the all properties again please!");
            }
        }
    }
}
