
using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs.create;
using SmartClinic.Core.DTOs.Update;
using SmartClinic.Core.Interfaces;

namespace SmartClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentsController(IAppointmentService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDto dto)
        {
            try
            {
                var ap = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = ap.Id }, ap);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ap = await _service.GetByIdAsync(id);
            if (ap == null) return NotFound();
            return Ok(ap);
        }

        [HttpGet("by-doctor/{doctorId}")]
        public async Task<IActionResult> ListByDoctor(Guid doctorId) => Ok(await _service.ListByDoctorAsync(doctorId));

        [HttpGet("by-patient/{patientId}")]
        public async Task<IActionResult> ListByPatient(Guid patientId) => Ok(await _service.ListByPatientAsync(patientId));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentUpdateDto dto)
        {
            try
            {
                var ap = await _service.UpdateAsync(id, dto);
                return Ok(ap);
            }
            catch (Exception ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _service.CancelAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(Guid id)
        {
            await _service.ApproveAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> Reject(Guid id)
        {
            await _service.RejectAsync(id);
            return NoContent();
        }
    }
}
