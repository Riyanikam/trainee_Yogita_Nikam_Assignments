using Microsoft.AspNetCore.Mvc;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Interface;

namespace VisitorManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSecurity([FromBody] SecurityDTO securityDto)
        {
            var result = await _securityService.AddSecurity(securityDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecurity(string id)
        {
            var result = await _securityService.GetSecurityById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSecurity()
        {
            var result = await _securityService.GetAllSecurity();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSecurity([FromBody] SecurityDTO securityDto)
        {
            var result = await _securityService.UpdateSecurity(securityDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurity(string id)
        {
            await _securityService.DeleteSecurity(id);
            return NoContent();
        }
    }
}
