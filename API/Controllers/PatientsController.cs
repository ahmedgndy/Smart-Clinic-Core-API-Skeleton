

using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;


namespace SmartClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientsController(IPatientService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _service.ListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            var created = await _service.CreateAsync(patient);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Patient patient)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, patient);
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
