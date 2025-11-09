using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;
using System;
using System.Threading.Tasks;

namespace SmartClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _service;
        public MedicationsController(IMedicationService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _service.ListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();
            return Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medication medication)
        {
            var created = await _service.CreateAsync(medication);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Medication medication)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, medication);
                return Ok(updated);
            }
            catch (ArgumentException e) { return NotFound(new { error = e.Message }); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
