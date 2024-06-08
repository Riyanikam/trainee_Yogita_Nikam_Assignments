using System.Collections.Generic;
using System.Threading.Tasks;
using VisitorSecuritySys.Entities;
namespace VisitorSecuritySys.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<VisitorEntity> AddVisitor(VisitorEntity visitor);
        Task<VisitorEntity> GetVisitorById(string id);
        Task<List<VisitorEntity>> GetAllVisitors();
        Task<VisitorEntity> UpdateVisitor(VisitorEntity visitor);
        Task DeleteVisitor(string id);


        Task<SecurityEntity> AddSecurity(SecurityEntity security);
        Task<SecurityEntity> GetSecurityById(string id);
        Task<List<SecurityEntity>> GetAllSecurities();
        Task<SecurityEntity> UpdateSecurity(SecurityEntity security);
        Task DeleteSecurity(string id);

        Task<ManagerEntity> AddManager(ManagerEntity manager);
        Task<ManagerEntity> GetManagerById(string id);
        Task<List<ManagerEntity>> GetAllManagers();
        Task<ManagerEntity> UpdateManager(ManagerEntity manager);
        Task DeleteManager(string id);

        Task<OfficeEntity> AddOffice(OfficeEntity office);
        Task<OfficeEntity> GetOfficeById(string id);
        Task<List<OfficeEntity>> GetAllOffices();
        Task<OfficeEntity> UpdateOffice(OfficeEntity office);
        Task DeleteOffice(string id);
    }
}
