using Assignmentfifth.DTO;
using Assignmentfifth.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assignmentfifth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeBasicDetailsController : Controller//Create the Controller
    {

        private readonly IEmployeeBasicDetails _employeeBasicDetails;

        public EmployeeBasicDetailsController(IEmployeeBasicDetails employeeBasicDetails)
        {
            _employeeBasicDetails = employeeBasicDetails;
        }

        //Add the Data here
        [HttpPost]

        public async Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _employeeBasicDetails.AddEmployee(employeeBasicDetailsDTO);
            return response;
        }
        //Here we are taking all the Employee from the Database
        [HttpGet]

        public async Task<List<EmployeeBasicDetailsDTO>> GetAllEmployee()
        {
            var response = await _employeeBasicDetails.GetAllEmployee();
            return response;
        }
        //Getting the the the UID 
        [HttpGet]

        public async Task<EmployeeBasicDetailsDTO> GetEmployeeByUId(string UId)
        {
            var response = await _employeeBasicDetails.GetEmployeeByUId(UId);
            return response;
        }
        // Updating the Employee
        [HttpPost]
        public async Task<EmployeeBasicDetailsDTO> UpdateEmployee(EmployeeBasicDetailsDTO employeeBasicDetailsDTO)
        {
            var response = await _employeeBasicDetails.UpdateEmployee(employeeBasicDetailsDTO);
            return response;
        }
        //Deleting the EMployee
        [HttpPost]
        public async Task<string> DeleteEmployee(string UId)
        {
            var response = await _employeeBasicDetails.DeleteEmployee(UId);
            return response;
        }
        //Getting the Employee from the Role Here
        [HttpGet]
        public async Task<List<EmployeeBasicDetailsDTO>> GetEmployeeByRole(string role)
        {
            var response = await _employeeBasicDetails.GetEmployeeByRole(role);
            return response;
        }

        //Apply the here Pagination
        [HttpPost]
        public async Task<EmployeeFilter> GetEmployeebypagination(EmployeeFilter employeeFilter)
        {
            var response = await _employeeBasicDetails.GetEmployeebypagination(employeeFilter);
            return response;
        }
    }
}

