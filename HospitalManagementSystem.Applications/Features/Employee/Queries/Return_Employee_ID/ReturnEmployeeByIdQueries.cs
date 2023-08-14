using AutoMapper;
using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
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

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_ID
{
    public class ReturnEmployeeByIdQueries : IRequest<Result<ReturnEmployeeByIdDTO>>
    {
        public Guid ID { get; set; }

        public ReturnEmployeeByIdQueries() { }

        public ReturnEmployeeByIdQueries(Guid id) {  ID = id; }
    }

    internal class ReturnEmployeeByIdQueriesHandler : IRequestHandler<ReturnEmployeeByIdQueries, Result<ReturnEmployeeByIdDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReturnEmployeeByIdQueriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReturnEmployeeByIdDTO>> Handle(ReturnEmployeeByIdQueries request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Repository<Employees>().ReturnEntityByIdAsync(request.ID);
            var result = _mapper.Map<ReturnEmployeeByIdDTO>(employee.Entity);

            return await Result<ReturnEmployeeByIdDTO>.SuccessAsync(result,
                _unitOfWork.Repository<Employees>().ReturnEntityByIdAsync(request.ID).Result.Message);
        }
    }
}
