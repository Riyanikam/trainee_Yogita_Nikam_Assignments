using Assignmentfifth.DTO;
using Assignmentfifth.Interface;
using Assignmentfifth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignmentfifth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAdditionalDetailsController : Controller//Created the Controller
    {
        private readonly EmployeeBasicDetailService _employeeAdditionalDetails;

        public EmployeeAdditionalDetailsController(EmployeeBasicDetailService employeeAdditionalDetails)
        {
            _employeeAdditionalDetails = employeeAdditionalDetails;
        }
        //Add the data for the Basic Detail
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
        /*[HtpGet]
         * public async
         */

        //Updated the Database 
        [HttpPost]
        public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
        {
            var response = await _employeeAdditionalDetails.UpdateAdditionalData(employeeAdditionalDetailsDTO);
            return response;
        }
        //Deleted from the Database
        [HttpPost]
        public async Task<string> DeleteEmployeeAdditional(string UId)
        {
            var response = await _employeeAdditionalDetails.DeleteEmployeeAdditional(UId);
            return response;
        }
        //for the PostRequest
        public async Task<List<EmployeeAdditonalDetailDTO>>AddEmployeeByMakeRequest(EmployeeAdditonalDetailDTO employeeadditionaldto)
        {
            var reponse=await EmployeeAdditonalDetailService.AddEmployeeByMakeRequest(Employee);
            return reponse;
        }
        //for the make get Request
        public async Task<EmployeeAdditonalDetailDTO> GetEmployeeByMakeRequest()
        {
            var response = await EmployeeAdditonalDetailService.GetEmployeeByMakeRequest();
            return response;
        }





    }
}

