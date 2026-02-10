using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMaintenanceMngAPI.Controllers
{
    [ApiController]
    [Route("api/requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requests;

        public RequestsController(IRequestService requests)
        {
            _requests = requests;
        }

        // GET /api/requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestReadDto>>> GetAll()
        {
            var items = await _requests.GetAllAsync();
            return Ok(items);
        }

        // GET /api/requests/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RequestReadDto>> GetById(int id)
        {
            var item = await _requests.GetByIdAsync(id);
            if (item is null) return NotFound();

            return Ok(item);
        }

        // POST /api/requests
        [HttpPost]
        public async Task<ActionResult<RequestReadDto>> Create([FromBody] RequestCreateDto dto)
        {
            try
            {
                var created = await _requests.CreateAsync(dto);
                if (created is null) return NotFound(); 

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT /api/requests/{id}  
        [HttpPut("{id:int}")]
        public async Task<ActionResult<RequestReadDto>> Update(int id, [FromBody] RequestUpdateDto dto)
        {
            try
            {
                var updated = await _requests.UpdateAsync(id, dto);
                if (updated is null) return NotFound();

                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE /api/requests/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _requests.DeleteAsync(id);
            if (!ok) return NotFound();

            return Ok();
        }
    }
}
