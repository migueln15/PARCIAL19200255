using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL19200255.DOMAIN.Core.Entities;
using PARCIAL19200255.DOMAIN.Core.Interfaces;

namespace PARCIAL19200255.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoPartsController : ControllerBase
    {
        private readonly IAutoPartsRepository _autoPartsRepository;

        public AutoPartsController(IAutoPartsRepository autoPartsRepository)
        {
            _autoPartsRepository = autoPartsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutoParts()
        {
            var autoParts = await _autoPartsRepository.GetAutoParts();
            return Ok(autoParts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoPartById(int id)
        {
            return Ok(await _autoPartsRepository.GetAutoPartById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutoPart([FromBody] AutoParts autoParts)
        {
            int id = await _autoPartsRepository.CreateAutoPart(autoParts);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutoPart([FromBody] AutoParts autoParts)
        {
            bool result = await _autoPartsRepository.UpdateAutoPart(autoParts);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoPart([FromRoute] int id)
        {
            var result = await _autoPartsRepository.DeleteAutoPart(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}
