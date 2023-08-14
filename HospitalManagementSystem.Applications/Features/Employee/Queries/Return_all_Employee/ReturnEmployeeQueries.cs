using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Wrapper_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee
{
    public record ReturnEmployeeQueries : IRequest<Result<IEnumerable<ReturnEmployeeDTO>>>;

    public class ReturnEmployeeQueriesHandler : IRequestHandler<ReturnEmployeeQueries, Result<IEnumerable<ReturnEmployeeDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReturnEmployeeQueriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ReturnEmployeeDTO>>> Handle(ReturnEmployeeQueries request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Repository<Employees>().Entities
                .ProjectTo<ReturnEmployeeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<IEnumerable<ReturnEmployeeDTO>>.SuccessAsync(employee, 
                _unitOfWork.Repository<Employees>().RetunrAllEntitiesAsync().Result.Message);
        }
    }
}
