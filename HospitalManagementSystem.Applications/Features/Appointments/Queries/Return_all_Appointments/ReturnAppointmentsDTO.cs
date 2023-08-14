using AutoMapper;
using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.AppointmentsNameSpace.Queries.Return_all_Appointments
{
    public class ReturnAppointmentsDTO : IMappingFrom<Appointments>
    {
        [JsonPropertyName("Full Name Employee")]
        public string FullNameEmployee { get; set; } = string.Empty;

        [JsonPropertyName("Email Employee")]
        public string EmailEmployee { get; set; } = string.Empty;

        [JsonPropertyName("Mobile Employee")]
        public string MobileEmployee { get; set; } = string.Empty;

        [JsonPropertyName("Full Name Patients")]
        public string FullNamePatients { get; set; } = string.Empty;

        [JsonPropertyName("Email Patients")]
        public string EmailPatients { get; set; } = string.Empty;

        [JsonPropertyName("Mobile Patients")]
        public string MobilePatients { get; set; } = string.Empty;

        [JsonPropertyName("Appointment Start Time")]
        public DateTime AppointmentStartTime { get; set; }

        [JsonPropertyName("Appointment End Time")]
        public DateTime AppointmentEndTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appointments, ReturnAppointmentsDTO>()
                .ForMember(destination => destination.FullNameEmployee,
                options => options.MapFrom(source => $"{source.InDepartment.Employees.FirstName} {source.InDepartment.Employees.LastName}"))
            .ForMember(destination => destination.EmailEmployee,
                options => options.MapFrom(source => source.InDepartment.Employees.Email))
            .ForMember(destination => destination.MobileEmployee,
                options => options.MapFrom(source => source.InDepartment.Employees.Mobile))
            .ForMember(destination => destination.FullNamePatients,
                options => options.MapFrom(source => $"{source.PatientsCases.Patients.FirstName} {source.PatientsCases.Patients.LastName}"))
            .ForMember(destination => destination.EmailPatients,
                options => options.MapFrom(source => source.PatientsCases.Patients.Email))
            .ForMember(destination => destination.MobilePatients,
                options => options.MapFrom(source => source.PatientsCases.Patients.Mobile));
        }
    }
}
