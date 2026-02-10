using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacilityMaintenanceMngAPI.Controllers
{
    [ApiController]
    [Route("api/facilities")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _facilities;

        public FacilitiesController(IFacilityService facilities)
        {
            _facilities = facilities;
        }

        // GET /api/facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityReadDto>>> GetAll()
        {
            var items = await _facilities.GetAllAsync();
            return Ok(items);
        }

        // GET /api/facilities/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FacilityReadDto>> GetById(int id)
        {
            var item = await _facilities.GetByIdAsync(id);
            if (item is null) return NotFound();

            return Ok(item);
        }

        // POST /api/facilities
        [HttpPost]
        public async Task<ActionResult<FacilityReadDto>> Create([FromBody] FacilityCreateDto dto)
        {
            var created = await _facilities.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT /api/facilities/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] FacilityUpdateDto dto)
        {
            var ok = await _facilities.UpdateAsync(id, dto);
            if (!ok) return NotFound();

            return Ok(); 
        }

        // DELETE /api/facilities/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _facilities.DeleteAsync(id);
            if (!ok) return NotFound();

            return Ok();
        }

        // GET /api/facilities/{facilityId}/requests
        [HttpGet("{facilityId:int}/requests")]
        public async Task<ActionResult<IEnumerable<RequestReadDto>>> GetRequestsForFacility(int facilityId)
        {
            var requests = await _facilities.GetRequestsForFacilityAsync(facilityId);
            if (requests is null) return NotFound(); 

            return Ok(requests);
        }
    }
}
