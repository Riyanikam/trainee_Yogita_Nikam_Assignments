using Microsoft.AspNetCore.Mvc;
using VisitorSecuritySys.DTO;
using VisitorSecuritySys.Interface;

namespace VisitorSecuritySys.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController:Controller
        {

            private readonly IVisitorService _VisitorService;

            public VisitorController(IVisitorService VisitorService)
            {
                _VisitorService = VisitorService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateVisitor(VisitorDTO VisitorDto)
            {
                var result = await _VisitorService.AddVisitor(VisitorDto);
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetVisitor(string id)
            {
                var result = await _VisitorService.GetVisitorById(id);
                return Ok(result);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllVisitor()
            {
                var result = await _VisitorService.GetAllVisitor();
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateVisitor(VisitorDTO VisitorDto)
            {
                var result = await _VisitorService.UpdateVisitor(VisitorDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteVisitor(string id)
            {
                await _VisitorService.DeleteVisitor(id);
                return NoContent();
            }
        }
    }





