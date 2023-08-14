using Hospital_Management_System_Applications.Features.AppointmentsNameSpace.Queries.Return_all_Appointments;
using Hospital_Management_System_DAL.Wrapper_Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System_WEB_API.Controllers
{
    public class AppointmentsController : ApplicationController
    {
        private readonly IMediator _mediator;
        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all appointments asynchronously.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the objects from database in good way!</response>
        [HttpGet("Return_Appointments")]
        public async Task<ActionResult<Result<IEnumerable<ReturnAppointmentsDTO>>>> ReturnAppointmentsAsync()
        {
            return await _mediator.Send(new ReturnAppointmentsQueries());
        }
    }
}
