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

        public ReturnEmployeeQueriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<ReturnEmployeeDTO>>> Handle(ReturnEmployeeQueries request, CancellationToken cancellationToken)
        {
            var configuration = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<Employees, ReturnEmployeeDTO>()
                .ForMember(destination => destination.FullName,
                options => options.MapFrom(source => $"{source.FirstName} {source.LastName}"));
            });

            var employee = await _unitOfWork.Repository<Employees>().Entities
                .ProjectTo<ReturnEmployeeDTO>(configuration.CreateMapper().ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<IEnumerable<ReturnEmployeeDTO>>.SuccessAsync(employee, 
                _unitOfWork.Repository<Employees>().RetunrAllEntitiesAsync().Result.Message);
        }
    }
}
