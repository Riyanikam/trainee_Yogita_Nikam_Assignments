using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Service
{
    public class ManagerService : IManagerService
    {
        private readonly ICosmosDBService _cosmosDBService;

        public ManagerService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        public async Task<ManagerEntity> AddManager(ManagerEntity manager)
        {
            return await _cosmosDBService.AddManager(manager);
        }

        public async Task<ManagerEntity> GetManagerById(string id)
        {
            return await _cosmosDBService.GetManagerById(id);
        }

        public async Task<IEnumerable<ManagerEntity>> GetAllManagers()
        {
            return await _cosmosDBService.GetAllManagers();
        }

        public async Task<ManagerEntity> UpdateManager(ManagerEntity manager)
        {
            return await _cosmosDBService.UpdateManager(manager);
        }

        public async Task DeleteManager(string id)
        {
            await _cosmosDBService.DeleteManager(id);
        }
    }
}
