using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMaintenanceMngAPI.Controllers
{
    [ApiController]
    [Route("api/technicians")]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianService _technicians;

        public TechniciansController(ITechnicianService technicians)
        {
            _technicians = technicians;
        }

        // GET /api/technicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicianReadDto>>> GetAll()
        {
            var items = await _technicians.GetAllAsync();
            return Ok(items);
        }

        // GET /api/technicians/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TechnicianReadDto>> GetById(int id)
        {
            var item = await _technicians.GetByIdAsync(id);
            if (item is null) return NotFound();

            return Ok(item);
        }

        // POST /api/technicians
        [HttpPost]
        public async Task<ActionResult<TechnicianReadDto>> Create([FromBody] TechnicianCreateDto dto)
        {
            var created = await _technicians.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT /api/technicians/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TechnicianUpdateDto dto)
        {
            var ok = await _technicians.UpdateAsync(id, dto);
            if (!ok) return NotFound();

            return Ok();
        }

        // DELETE /api/technicians/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _technicians.DeleteAsync(id);
            if (!ok) return NotFound();

            return Ok();
        }
    }
}
