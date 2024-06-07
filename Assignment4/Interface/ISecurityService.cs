using VisitorSecuritySys.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VisitorSecuritySys.Interface
{
    public interface ISecurityService
    {
        Task<SecurityDTO> AddSecurity(SecurityDTO securityDto);
        Task<SecurityDTO> GetSecurityById(string id);
        Task<IEnumerable<SecurityDTO>> GetAllSecurity();
        Task<SecurityDTO> UpdateSecurity(SecurityDTO securityDto);
        Task DeleteSecurity(string id);
    }
}
