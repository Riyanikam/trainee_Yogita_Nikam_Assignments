using Assignmentfifth.DTO;
using Assignmentfifth.Interface;
using Assignmentfifth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignmentfifth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAdditionalDetailsController : Controller
    {
        private readonly EmployeeBasicDetailService _employeeAdditionalDetails;

        public EmployeeAdditionalDetailsController(EmployeeBasicDetailService employeeAdditionalDetails)
        {
            _employeeAdditionalDetails = employeeAdditionalDetails;
        }
        [HttpPost]

        public async Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeAdditinalDetailsDTO)
        {
            var response = await _employeeAdditionalDetails.Add_AdditionalData(employeeAdditinalDetailsDTO);
            return response;
        }
        [HttpGet]

        public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData()
        {
            var response = await _employeeAdditionalDetails.GetAllEmployeeAdditionalData();
            return response;
        }
        [HttpGet]

        public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string UId)
        {
            var response = await _employeeAdditionalDetails.GetEmployeeAdditionalDataByUId(UId);
            return response;
        }


        [HttpPost]
        public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
        {
            var response = await _employeeAdditionalDetails.UpdateAdditionalData(employeeAdditionalDetailsDTO);
            return response;
        }

        [HttpPost]
        public async Task<string> DeleteEmployeeAdditional(string UId)
        {
            var response = await _employeeAdditionalDetails.DeleteEmployeeAdditional(UId);
            return response;
        }


    }
}

