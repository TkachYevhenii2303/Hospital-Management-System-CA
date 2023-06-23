using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using Hospital_Management_System_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee
{
    public class ReturnEmployeeDTO : IMappingFrom<Employees>
    {
        [JsonPropertyName("Employee's title:")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("Email:")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Locale mobile:")]
        public string Mobile { get; set; } = string.Empty;
    }
}
