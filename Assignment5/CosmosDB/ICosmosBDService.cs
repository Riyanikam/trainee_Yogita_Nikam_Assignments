using Assignmentfifth.Entity;

namespace Assignmentfifth.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeeBasicDetailsEntity);
        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployee();

        Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string UId);

        Task ReplaceAsync(dynamic employee);


        Task<EmployeeAdditionalDetailsEntity> Add_AdditionalData(EmployeeAdditionalDetailsEntity employeeAdditionalDetailsEntity);


        Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalData();

        Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDataByUId(string uId);
    }
}

