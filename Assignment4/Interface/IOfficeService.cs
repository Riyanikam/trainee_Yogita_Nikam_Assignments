using VisitorSecuritySys.DTO;

namespace VisitorSecuritySys.Interface
{
    public interface IOfficeService
    {
        Task<OfficeDTO> AddOffice(OfficeDTO officeDto);
        Task<OfficeDTO> GetOfficeById(string id);
        Task<IEnumerable<OfficeDTO>> GetAllOffices();
        Task<OfficeDTO> UpdateOffice(OfficeDTO officeDto);
        Task DeleteOffice(string id);
    }
}
