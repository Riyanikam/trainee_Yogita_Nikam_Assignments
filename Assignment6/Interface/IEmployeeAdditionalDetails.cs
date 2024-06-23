using Assignmentfifth.DTO;

namespace Assignmentfifth.Interface
{
    public class IEmployeeAdditonalDetail
    {
        public interface IEmployeeAdditionalDetails
        {
            Task<EmployeeAdditionalDetailsDTO> AddEmployeeByMakeRequest(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO);

            Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeAdditinalDetailsDTO);

            Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData();

            Task<EmployeeAdditionalDetailsDTO> GetEmployeeByMakeGetRequest(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO);

            Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string uId);

            Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO);

            Task<string> DeleteEmployeeAdditional(string UId);

        }
    }
}
