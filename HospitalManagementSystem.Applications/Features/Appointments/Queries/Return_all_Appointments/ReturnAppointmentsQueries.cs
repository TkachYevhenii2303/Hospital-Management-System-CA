using AutoMapper;
using Hospital_Management_System_Applications.Interfaces.Patterns;
using Hospital_Management_System_Applications.Interfaces.Repositories;
using Hospital_Management_System_DAL.Wrapper_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.AppointmentsNameSpace.Queries.Return_all_Appointments
{
    public record ReturnAppointmentsQueries : IRequest<Result<IEnumerable<ReturnAppointmentsDTO>>>;

    internal class ReturnAppointmentsQueriesHandler : IRequestHandler<ReturnAppointmentsQueries, Result<IEnumerable<ReturnAppointmentsDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppointmentsRepository _appointmentsRepository;

        public ReturnAppointmentsQueriesHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppointmentsRepository appointmentsRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<Result<IEnumerable<ReturnAppointmentsDTO>>> Handle(ReturnAppointmentsQueries request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentsRepository.ReturnAppointmentsAsync();
            var result = _mapper.Map<IEnumerable<ReturnAppointmentsDTO>>(appointments.Entity);

            return await Result<IEnumerable<ReturnAppointmentsDTO>>.SuccessAsync(result, appointments.Message);
        }
    }
}
