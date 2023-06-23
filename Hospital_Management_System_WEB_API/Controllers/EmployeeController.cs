using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_DAL.Wrapper_Response;
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
    }
}
