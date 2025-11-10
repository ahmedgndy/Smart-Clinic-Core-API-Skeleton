using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.Interfaces;
using SmartClinic.Core.Models;

//make a service for this 
namespace SmartClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionItemController : ControllerBase
    {
        private readonly IRepository<PrescriptionItem> _repository;

        public PrescriptionItemController(IRepository<PrescriptionItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.ListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionItem item)
        {
            await _repository.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PrescriptionItem item)
        {
            if (id != item.Id)
                return BadRequest();

            await _repository.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
