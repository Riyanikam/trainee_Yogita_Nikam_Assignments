using Assignmentfifth.DTO;

namespace Assignmentfifth.Interface
{
    public interface IEmployeeBasicDetails
    {

        Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO);

        Task<List<EmployeeBasicDetailsDTO>> GetAllEmployee();

        Task<EmployeeBasicDetailsDTO> GetEmployeeByUId(string UId);

        Task<EmployeeBasicDetailsDTO> UpdateEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO);

        Task<string> DeleteEmployee(string uId);

        Task<List<EmployeeBasicDetailsDTO>> GetEmployeeByRole(string role);

        Task<EmployeeFilter> GetEmployeebypagination(EmployeeFilter employeeFilter);

    }
}
