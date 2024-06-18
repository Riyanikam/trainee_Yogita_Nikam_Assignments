using Assignmentfifth.DTO;
using Assignmentfifth.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assignmentfifth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeBasicDetailsController : Controller //here we have make the Controller
    {

        private readonly IEmployeeBasicDetails _employeeBasicDetails;

        public EmployeeBasicDetailsController(IEmployeeBasicDetails employeeBasicDetails)
        {
            _employeeBasicDetails = employeeBasicDetails;
        }
        //Add the to the Database
        [HttpPost]

        public async Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _employeeBasicDetails.AddEmployee(employeeBasicDetailsDTO);
            return response;
        }
        //Get all the Employee 
        [HttpGet]

        public async Task<List<EmployeeBasicDetailsDTO>> GetAllEmployee()
        {
            var response = await _employeeBasicDetails.GetAllEmployee();
            return response;
        }
        //Get all the Employee by the UID
        [HttpGet]

        public async Task<EmployeeBasicDetailsDTO> GetEmployeeByUId(string UId)
        {
            var response = await _employeeBasicDetails.GetEmployeeByUId(UId);
            return response;
        }
        //here we have updating the Employee
        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> UpdateEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _employeeBasicDetails.UpdateEmployee(employeeBasicDetailsDTO);
            return response;
        }
        //Here we have deleting the Employee
        [HttpPost]
        public async Task<string> DeleteEmployee(string UId)
        {
            var response = await _employeeBasicDetails.DeleteEmployee(UId);
            return response;
        }
        //Here we have get the employee by the role
        [HttpGet]
        public async Task<List<EmployeeBasicDetailsDTO>> GetEmployeeByRole(string role)
        {
            var response = await _employeeBasicDetails.GetEmployeeByRole(role);
            return response;
        }

        //Here I had Implement Pagination
        [HttpPost]
        public async Task<EmployeeFilter> GetEmployeebypagination(EmployeeFilter employeeFilter)
        {
            var response = await _employeeBasicDetails.GetEmployeebypagination(employeeFilter);
            return response;
        }
    }
}

