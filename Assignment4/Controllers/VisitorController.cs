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
                VisitorService = VisitorService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateVisitor(VisitorDTO VisitorDto)
            {
                var result = await VisitorService.AddVisitor(VisitorDto);
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetVisitor(string id)
            {
                var result = await VisitorService.GetVisitorById(id);
                return Ok(result);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllVisitor()
            {
                var result = await VisitorService.GetAllVisitor();
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateVisitor(VisitorDTO VisitorDto)
            {
                var result = await VisitorService.UpdateVisitor(VisitorDto);
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteVisitor(string id)
            {
                await VisitorService.DeleteVisitor(id);
                return NoContent();
            }
        }
    }





