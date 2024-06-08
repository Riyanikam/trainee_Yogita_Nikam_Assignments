using VisitorSecuritySys.DTO;

namespace VisitorSecuritySys.Interface
{
    public interface IVisitorService
    {
        Task<VisitorDTO> AddVisitor(VisitorDTO visitorDto);
        Task<VisitorDTO> GetVisitorById(string id);
        Task<IEnumerable<VisitorDTO>> GetAllVisitor();
        Task<VisitorDTO> UpdateVisitor(VisitorDTO visitorDto);
        Task DeleteVisitor(string id);
    }

}
