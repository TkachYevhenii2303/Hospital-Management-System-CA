using Hospital_Management_System_Applications.Features.Employee.Commands.Create_Employee;
using Hospital_Management_System_Applications.Features.Employee.Commands.Delete_Employee;
using Hospital_Management_System_Applications.Features.Employee.Commands.Insert_Employee;
using Hospital_Management_System_Applications.Features.Employee.Commands.Update_Employee;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_ID;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_with_Pagination;
using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_Shared.Paginatio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System_WEB_API.Controllers
{
    public class EmployeeController : ApplicationController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all employees asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the objects from database in good way!</response>
        [HttpGet("Return_all_Employee")]
        public async Task<ActionResult<Result<IEnumerable<ReturnEmployeeDTO>>>> ReturnEmployeeAsync()
        {
            return await _mediator.Send(new ReturnEmployeeQueries());
        }

        /// <summary>
        /// Retrieves an employee asynchronously by their ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to retrieve.</param>
        /// <returns>An ActionResult containing a ResultResponse with a GetEmployeesDTO.</returns>
        [HttpGet("Return_Employee/{ID}")]
        public async Task<ActionResult<Result<ReturnEmployeeByIdDTO>>> ReturnEmployeeByIdAsync(Guid ID)
        {
            return await _mediator.Send(new ReturnEmployeeByIdQueries(ID));
        }

        /// <summary>
        /// Retrieves an employee asynchronously using Pagination function
        /// </summary>
        /// <param name="query">ReturnEmployeePaginationQuery object and base settings</param>
        /// <returns>An ActionResult containing a PaginationResult with a ReturnEmployeeWithPaginationDTO.</returns>
        [HttpGet("Return_Employee_With_Pagination")]
        public async Task<ActionResult<PaginationResult<ReturnEmployeeWithPaginationDTO>>> 
            ReturnEmployeeWithPagination([FromQuery] ReturnEmployeePaginationQuery query)
        {
            var validator = new PaginationEmployeeValidator();

            var result = validator.Validate(query);

            if (!result.IsValid) { return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList()); }

            return await _mediator.Send(query);
        }

        /// <summary>
        /// Inserts a new employee asynchronously.
        /// </summary>
        /// <param name="employeeCommand">The data of the employeeCommand to insert.</param>
        /// <returns>An ActionResult containing a Result Wrapper with a ReturnEmployeeDTO representing the inserted employee.</returns>
        [HttpPost("Insert_Employee")]
        public async Task<ActionResult<Result<ReturnEmployeeDTO>>> InsertEmployeeAsync(InsertEmployeeCommand employeeCommand)
        {
            var validator = new InsertEmployeeValidator();

            var result = validator.Validate(employeeCommand);

            if (!result.IsValid) { return BadRequest(result.Errors.Select(x => x.ErrorMessage).ToList()); }

            return await _mediator.Send(employeeCommand);
        }

        /// <summary>
        /// Updates an existing employee asynchronously.
        /// </summary>
        /// <param name="ID">Guid ID for founding employee</param>
        /// <param name="employeeCommand">The updated data of the employee.</param>
        /// <returns>An ActionResult containing a ResultResponse with a GetEmployeesDTO representing the updated employee.</returns>
        /// <response code="200">Returns the objects from database in good way!</response>
        /// <response code="400">Not founding the object in this database!</response>
        [HttpPut("Update_Employee")]
        public async Task<ActionResult<Result<ReturnEmployeeDTO>>> UpdateEmployeeAsync(Guid ID, 
            UpdateEmployeeCommand employeeCommand)
        {
            if (ID != employeeCommand.ID) { return BadRequest(); }

            return await _mediator.Send(employeeCommand);
        }

        /// <summary>
        /// Deletes an employee asynchronously by their ID.
        /// </summary>
        /// <param name="ID">The ID of the employee to delete.</param>
        /// <returns>An ActionResult containing a ResultResponse with an IEnumerable of GetEmployeesDTO after the deletion.</returns>
        [HttpDelete("Delete_Employee")]
        public async Task<ActionResult<Result<IEnumerable<ReturnEmployeeDTO>>>> DeleteEmployeeAsync(Guid ID)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(ID));
        }
    }
}
