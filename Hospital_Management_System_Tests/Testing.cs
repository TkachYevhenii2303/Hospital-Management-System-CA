using System.Collections;
using System.Runtime.InteropServices;
using AutoMapper;
using FluentAssertions;
using Hospital_Management_System_Applications.Features.AppointmentsNameSpace.Queries.Return_all_Appointments;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_DAL.Wrapper_Response;
using Hospital_Management_System_WEB_API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Hospital_Management_System_Tests;

public class Testing
{
    [Fact] 
    public void Return_Appointments_ReturnStatusCode200()
    {
        var mediator = new Mock<IMediator>();
        mediator.Setup(_ => _.Send(new ReturnAppointmentsQueries(), 
            It.IsAny<CancellationToken>()));

        var controller = new AppointmentsController(mediator.Object);
        var result = controller.ReturnAppointmentsAsync().Result.Result as OkObjectResult;

        result?.StatusCode.Should().Be(200);
    }
}