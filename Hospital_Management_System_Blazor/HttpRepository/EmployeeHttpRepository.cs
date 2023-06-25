using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_Blazor.HttpRepository.Interfaces;
using Hospital_Management_System_DAL.Wrapper_Response;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hospital_Management_System_Blazor.HttpRepository
{
    public class EmployeeHttpRepository : IEmployeeHttpRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public EmployeeHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<Result<IEnumerable<ReturnEmployeeDTO>>> ReturnEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        /*   public async Task<Result<IEnumerable<ReturnEmployeeDTO>>> ReturnEmployeeAsync()
           {
               var response = await _httpClient.GetAsync("Return_all_Employee");
               var content = await response.Content.ReadAsStringAsync();

               if (response.IsSuccessStatusCode is not true)
               {
                   throw new ApplicationException(content);
               }

               var employee = JsonSerializer.
           }*/
    }
}
