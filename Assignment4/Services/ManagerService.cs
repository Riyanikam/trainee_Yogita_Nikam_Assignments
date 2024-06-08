using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorSecuritySys.CosmosDB;
using VisitorSecuritySys.Entities;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Service
{
    public class ManagerService : IManagerService
    {
        private readonly ICosmosDBService cosmosDBService;

        public ManagerService(ICosmosDBService cosmosDBService)
        {
            cosmosDBService = cosmosDBService;
        }

        public async Task<ManagerEntity> AddManager(ManagerEntity manager)
        {
            return await cosmosDBService.AddManager(manager);
        }

        public async Task<ManagerEntity> GetManagerById(string id)
        {
            return await cosmosDBService.GetManagerById(id);
        }

        public async Task<IEnumerable<ManagerEntity>> GetAllManagers()
        {
            return await cosmosDBService.GetAllManagers();
        }

        public async Task<ManagerEntity> UpdateManager(ManagerEntity manager)
        {
            return await cosmosDBService.UpdateManager(manager);
        }

        public async Task DeleteManager(string id)
        {
            await cosmosDBService.DeleteManager(id);
        }
    }
}
