using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs.Create;
using SmartClinic.Core.Interfaces;


namespace SmartClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        public PrescriptionsController(IPrescriptionService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PrescriptionCreateDto dto)
        {
            try
            {
                var p = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = p.Id }, p);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpGet("by-patient/{patientId}")]
        public async Task<IActionResult> ListByPatient(Guid patientId) => Ok(await _service.ListByPatientAsync(patientId));
    }
}
