using Assignmentfifth.Overall;
using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using System.Net;
using Assignmentfifth.Entity;

namespace Assignmentfifth.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public readonly CosmosClient _cosmosClient;
        private readonly Microsoft.Azure.Cosmos.Container _container;
        public CosmosDBService()

        {
            _cosmosClient = new CosmosClient(Main.CosmosEndPoint, Main.PrimaryKey);
            _container = _cosmosClient.GetContainer(Main.databaseName, Main.containerName);
        }
        public async Task<EmployeeBasicDetailEntity> AddEmployee(EmployeeBasicDetailEntity employee)
        {
            var response = await _container.CreateItemAsync(employee);
            return response;
        }
        public async Task<List<EmployeeBasicDetailsEntity>> GetAllEmployee()
        {
            var response = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(a => a.Active == true && a.Archived == false
            && a.DocumentType == Main.EmployeeDocumentType).ToList();
            return response;
        }
        public async Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string uId)
        {
            var employee = _container.GetItemLinqQueryable<EmployeeBasicDetailsEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Main.EmployeeDocumentType).FirstOrDefault();
            return employee;
        }

        public async Task ReplaceAsync(dynamic entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
        }


        public async Task<EmployeeAdditionalDetailsEntity> Add_AdditionalData(EmployeeAdditionalDetailsEntity employee)
        {
            var response = await _container.CreateItemAsync(employee);
            return response;
        }
        public async Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalData()
        {
            var response = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(a => a.Active == true && a.Archived == false
            && a.DocumentType == Main.EmployeeDocumentType).ToList();
            return response;
        }


        public async Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDataByUId(string uId)
        {
            var employee = _container.GetItemLinqQueryable<EmployeeAdditionalDetailsEntity>(true).Where(a => a.UId == uId && !a.Archived
            && a.Active && a.DocumentType == Main.EmployeeDocumentType).FirstOrDefault();
            return employee;
        }
    }
}
