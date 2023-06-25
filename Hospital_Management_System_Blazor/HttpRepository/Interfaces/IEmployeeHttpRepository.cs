using Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee;
using Hospital_Management_System_DAL.Wrapper_Response;

namespace Hospital_Management_System_Blazor.HttpRepository.Interfaces
{
    public interface IEmployeeHttpRepository
    {
        Task<Result<IEnumerable<ReturnEmployeeDTO>>> ReturnEmployeeAsync();
    }
}
