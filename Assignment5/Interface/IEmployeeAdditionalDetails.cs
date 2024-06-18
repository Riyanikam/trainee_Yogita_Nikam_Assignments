using Assignmentfifth.DTO;

namespace Assignmentfifth.Interface
{
    public class IEmployeeAdditonalDetail
    {
        public interface IEmployeeAdditionalDetails
        {
            Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeAdditinalDetailsDTO);
            Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData();

            Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string uId);

            Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO);

            Task<string> DeleteEmployeeAdditional(string UId);

        }
    }
}
