using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_with_Pagination
{
    public class PaginationEmployeeValidator : AbstractValidator<ReturnEmployeePaginationQuery>
    {
        public PaginationEmployeeValidator()
        {
            RuleFor(x => x.PageNumber)
               .GreaterThanOrEqualTo(1)
               .WithMessage("The page number must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The page size must be greater than or equal to 1.");
        }
    }
}
