using FacilityMaintenanceMngAPI.Data;
using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacilityMaintenanceMngAPI.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly AppDbContext _db;

        public FacilityService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FacilityReadDto>> GetAllAsync()
        {
            return await _db.Facilities
                .AsNoTracking()
                .OrderBy(f => f.Id)
                .Select(f => new FacilityReadDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location
                })
                .ToListAsync();
        }

        public async Task<FacilityReadDto?> GetByIdAsync(int id)
        {
            return await _db.Facilities
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Select(f => new FacilityReadDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location
                })
                .FirstOrDefaultAsync();
        }

        public async Task<FacilityReadDto> CreateAsync(FacilityCreateDto dto)
        {
            var entity = new Models.Facility
            {
                Name = dto.Name.Trim(),
                Location = dto.Location.Trim()
            };

            _db.Facilities.Add(entity);
            await _db.SaveChangesAsync();

            return new FacilityReadDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location
            };
        }

        public async Task<bool> UpdateAsync(int id, FacilityUpdateDto dto)
        {
            var facility = await _db.Facilities.FirstOrDefaultAsync(f => f.Id == id);
            if (facility is null) return false;

            facility.Name = dto.Name.Trim();
            facility.Location = dto.Location.Trim();

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var facility = await _db.Facilities.FirstOrDefaultAsync(f => f.Id == id);
            if (facility is null) return false;

            _db.Facilities.Remove(facility);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RequestReadDto>?> GetRequestsForFacilityAsync(int facilityId)
        {
            var exists = await _db.Facilities.AnyAsync(f => f.Id == facilityId);
            if (!exists) return null;

            return await _db.MaintenanceRequests
                .AsNoTracking()
                .Where(r => r.FacilityId == facilityId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RequestReadDto
                {
                    Id = r.Id,
                    FacilityId = r.FacilityId,
                    FacilityName = r.Facility!.Name,
                    TechnicianId = r.TechnicianId,
                    TechnicianName = r.Technician != null ? r.Technician.FullName : null,
                    Title = r.Title,
                    Description = r.Description,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt
                })
                .ToListAsync();
        }
    }
}

