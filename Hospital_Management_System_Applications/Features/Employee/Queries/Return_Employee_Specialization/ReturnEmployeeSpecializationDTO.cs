using AutoMapper;
using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_ID;
using Hospital_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_Employee_Specialization
{
    public class ReturnEmployeeSpecializationDTO : IMappingFrom<Employees>
    {
        [JsonPropertyName("Employee's title:")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("Email:")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Locale mobile:")]
        public string Mobile { get; set; } = string.Empty;

        [JsonPropertyName("Specialization:")]
        public string Specialization { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employees, ReturnEmployeeSpecializationDTO>()
                .ForMember(destination => destination.FullName,
                options => options.MapFrom(source => $"{source.FirstName} {source.LastName}"))
                
                .ForMember(destination => destination.Specialization,
                options => options.MapFrom(source => source.HasRoles.FirstOrDefault().Roles.RolesTitle));
        }
    }
}
