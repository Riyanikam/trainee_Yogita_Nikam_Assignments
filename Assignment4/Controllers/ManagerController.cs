using Microsoft.AspNetCore.Mvc;
using VisitorSecuritySys.Interface;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Entities;

namespace VisitorSecuritySys.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(ManagerDTO managerDto)
        {
            var managerEntity = new ManagerEntity
            {
                Id = managerDto.Id,
                Name = managerDto.Name,
                Email = managerDto.Email,
                Phone = managerDto.PhoneNumber,
                Department = managerDto.Department,
                Location = managerDto.Location
            };

            var result = await _managerService.AddManager(managerEntity);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManager(string id)
        {
            var result = await _managerService.GetManagerById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManagers()
        {
            var result = await _managerService.GetAllManagers();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManager(ManagerDTO managerDto)
        {
            var managerEntity = new ManagerEntity
            {
                Id = managerDto.Id,
                Name = managerDto.Name,
                Email = managerDto.Email,
                Phone = managerDto.PhoneNumber,
                Department = managerDto.Department,
                Location = managerDto.Location
            };

            var result = await _managerService.UpdateManager(managerEntity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(string id)
        {
            var manager = await _managerService.GetManagerById(id);
            if (manager == null)
            {
                return NotFound();
            }

            await _managerService.DeleteManager(id);
            return NoContent();
        }
    }
}
