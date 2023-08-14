using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hospital_Management_System_Applications.Extensions;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_Shared.Paginatio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_with_Pagination
{
    public record ReturnEmployeePaginationQuery : IRequest<PaginationResult<ReturnEmployeeWithPaginationDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ReturnEmployeePaginationQuery() { }

        public ReturnEmployeePaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class ReturnEmployeeWithPaginationQueryHandler : IRequestHandler<ReturnEmployeePaginationQuery, PaginationResult<ReturnEmployeeWithPaginationDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReturnEmployeeWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationResult<ReturnEmployeeWithPaginationDTO>> Handle(ReturnEmployeePaginationQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Employees>().Entities
                .OrderBy(x => x.FirstName)
                .ProjectTo<ReturnEmployeeWithPaginationDTO>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);

            result.Message = "The employee have been successfully retrieved with pagination. " +
                $"The requested page number {result.TotalPages/result.PageSize} and page size {result.PageSize} " +
                $"were applied to the query, resulting in a subset of players that meets the specified criteria";

            result.StatusCode = 200;

            return result;
        }
    }
}
