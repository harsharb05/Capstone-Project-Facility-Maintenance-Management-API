using FacilityMaintenanceMngAPI.Data;
using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using FacilityMaintenanceMngAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityMaintenanceMngAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly AppDbContext _db;

        public RequestService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RequestReadDto>> GetAllAsync()
        {
            return await _db.MaintenanceRequests
                .AsNoTracking()
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

        public async Task<RequestReadDto?> GetByIdAsync(int id)
        {
            return await _db.MaintenanceRequests
                .AsNoTracking()
                .Where(r => r.Id == id)
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
                .FirstOrDefaultAsync();
        }

        public async Task<RequestReadDto?> CreateAsync(RequestCreateDto dto)
        {
           
            var facility = await _db.Facilities.FirstOrDefaultAsync(f => f.Id == dto.FacilityId);
            if (facility is null) return null;

            
            Technician? tech = null;
            if (dto.TechnicianId.HasValue)
            {
                tech = await _db.Technicians.FirstOrDefaultAsync(t => t.Id == dto.TechnicianId.Value);
                if (tech is null)
                    throw new ArgumentException("TechnicianId is invalid.");
            }

            var entity = new MaintenanceRequest
            {
                FacilityId = dto.FacilityId,
                TechnicianId = dto.TechnicianId,
                Title = dto.Title.Trim(),
                Description = dto.Description?.Trim(),
                Status = RequestStatus.Open,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _db.MaintenanceRequests.Add(entity);
            await _db.SaveChangesAsync();

            return new RequestReadDto
            {
                Id = entity.Id,
                FacilityId = facility.Id,
                FacilityName = facility.Name,
                TechnicianId = tech?.Id,
                TechnicianName = tech?.FullName,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public async Task<RequestReadDto?> UpdateAsync(int id, RequestUpdateDto dto)
        {
            var request = await _db.MaintenanceRequests
                .Include(r => r.Facility)
                .Include(r => r.Technician)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request is null) return null;

           
            if (dto.TechnicianId.HasValue)
            {
                var techExists = await _db.Technicians.AnyAsync(t => t.Id == dto.TechnicianId.Value);
                if (!techExists)
                    throw new ArgumentException("TechnicianId is invalid.");
            }

            request.TechnicianId = dto.TechnicianId;
            request.Status = dto.Status;
            request.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

           
            var techName = request.TechnicianId is null
                ? null
                : await _db.Technicians
                    .Where(t => t.Id == request.TechnicianId.Value)
                    .Select(t => t.FullName)
                    .FirstOrDefaultAsync();

            return new RequestReadDto
            {
                Id = request.Id,
                FacilityId = request.FacilityId,
                FacilityName = request.Facility?.Name ?? "",
                TechnicianId = request.TechnicianId,
                TechnicianName = techName,
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                CreatedAt = request.CreatedAt,
                UpdatedAt = request.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var request = await _db.MaintenanceRequests.FirstOrDefaultAsync(r => r.Id == id);
            if (request is null) return false;

            _db.MaintenanceRequests.Remove(request);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
