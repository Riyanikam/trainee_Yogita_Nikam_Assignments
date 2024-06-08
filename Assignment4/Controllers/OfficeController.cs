using Microsoft.AspNetCore.Mvc;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Interface;

namespace VisitorManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _OfficeService;

        public OfficeController(IOfficeService OfficeService)
        {
            _OfficeService = OfficeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffice([FromBody] OfficeDTO officeDto)
        {
            var result = await _OfficeService.AddOffice(officeDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffice(string id)
        {
            var result = await _OfficeService.GetOfficeById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOffices()
        {
            var result = await _OfficeService.GetAllOffices();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOffice( OfficeDTO officeDto)
        {
            var result = await _OfficeService.UpdateOffice(officeDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(string id)
        {
            await _OfficeService.DeleteOffice(id);
            return NoContent();
        }
    }
}
