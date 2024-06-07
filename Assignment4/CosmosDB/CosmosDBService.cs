using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;
using VisitorSecuritySys.Overall;

namespace VisitorSecuritySys.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Main.URI, Main.PrimaryKey);
            _container = _cosmosClient.GetContainer(Main.DatabaseName, Main.ContainerName);
        }

        // Visitor methods
        public async Task<VisitorEntity> AddVisitor(VisitorEntity visitor)
        {
            var response = await _container.CreateItemAsync(visitor);
            return response.Resource;
        }

        public async Task<VisitorEntity> GetVisitorById(string id)
        {
            try
            {
                ItemResponse<VisitorEntity> response = await _container.ReadItemAsync<VisitorEntity>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }

        public async Task<List<VisitorEntity>> GetAllVisitors()
        {
            var query = _container.GetItemQueryIterator<VisitorEntity>(new QueryDefinition("SELECT * FROM c WHERE c.Active = true"));
            var results = new List<VisitorEntity>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<VisitorEntity> UpdateVisitor(VisitorEntity visitor)
        {
            var response = await _container.UpsertItemAsync(visitor);
            return response.Resource;
        }

        public async Task DeleteVisitor(string id)
        {
            await _container.DeleteItemAsync<VisitorEntity>(id, new PartitionKey(id));
        }

        // Security methods
        public async Task<SecurityEntity> AddSecurity(SecurityEntity security)
        {
            try
            {
                var response = await _container.CreateItemAsync(security);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error adding security entity: {ex}");
                throw; // Rethrow the exception or handle it based on your application's requirements
            }
        }

        public async Task<SecurityEntity> GetSecurityById(string id)
        {
            try
            {
                ItemResponse<SecurityEntity> response = await _container.ReadItemAsync<SecurityEntity>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error getting security entity by ID: {ex}");
                throw; // Rethrow the exception or handle it based on your application's requirements
            }
        }

        public async Task<List<SecurityEntity>> GetAllSecurities()
        {
            try
            {
                var query = _container.GetItemQueryIterator<SecurityEntity>(new QueryDefinition("SELECT * FROM c WHERE c.Active = true"));
                var results = new List<SecurityEntity>();

                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }
            catch (CosmosException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error getting all security entities: {ex}");
                throw; // Rethrow the exception or handle it based on your application's requirements
            }
        }

        public async Task<SecurityEntity> UpdateSecurity(SecurityEntity security)
        {
            try
            {
                var response = await _container.UpsertItemAsync(security);
                return response.Resource;
            }
            catch (CosmosException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error updating security entity: {ex}");
                throw; // Rethrow the exception or handle it based on your application's requirements
            }
        }

        public async Task DeleteSecurity(string id)
        {
            try
            {
                await _container.DeleteItemAsync<SecurityEntity>(id, new PartitionKey(id));
            }
            catch (CosmosException ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Error deleting security entity: {ex}");
                throw; // Rethrow the exception or handle it based on your application's requirements
            }
        }


        // Manager methods
        public async Task<ManagerEntity> AddManager(ManagerEntity manager)
        {
            var response = await _container.CreateItemAsync(manager, new PartitionKey(manager.Id));
            return response.Resource;
        }

        public async Task<ManagerEntity> GetManagerById(string id)
        {
            try
            {
                ItemResponse<ManagerEntity> response = await _container.ReadItemAsync<ManagerEntity>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }

        public async Task<List<ManagerEntity>> GetAllManagers()
        {
            var query = _container.GetItemQueryIterator<ManagerEntity>(new QueryDefinition("SELECT * FROM c WHERE c.Active = true"));
            var results = new List<ManagerEntity>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<ManagerEntity> UpdateManager(ManagerEntity manager)
        {
            var response = await _container.UpsertItemAsync(manager, new PartitionKey(manager.Id));
            return response.Resource;
        }

        public async Task DeleteManager(string id)
        {
            await _container.DeleteItemAsync<ManagerEntity>(id, new PartitionKey(id));
        }

        // Office methods
        public async Task<OfficeEntity> AddOffice(OfficeEntity office)
        {
            var response = await _container.CreateItemAsync(office);
            return response.Resource;
        }

        public async Task<OfficeEntity> GetOfficeById(string id)
        {
            try
            {
                ItemResponse<OfficeEntity> response = await _container.ReadItemAsync<OfficeEntity>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }

        public async Task<List<OfficeEntity>> GetAllOffices()
        {
            var query = _container.GetItemQueryIterator<OfficeEntity>(new QueryDefinition("SELECT * FROM c WHERE c.Active = true"));
            var results = new List<OfficeEntity>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<OfficeEntity> UpdateOffice(OfficeEntity office)
        {
            var response = await _container.UpsertItemAsync(office);
            return response.Resource;
        }

        public async Task DeleteOffice(string id)
        {
            await _container.DeleteItemAsync<OfficeEntity>(id, new PartitionKey(id));
        }
    }
}
