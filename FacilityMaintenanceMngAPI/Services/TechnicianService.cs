using FacilityMaintenanceMngAPI.Data;
using FacilityMaintenanceMngAPI.DTOs;
using FacilityMaintenanceMngAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FacilityMaintenanceMngAPI.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly AppDbContext _db;

        public TechnicianService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TechnicianReadDto>> GetAllAsync()
        {
            return await _db.Technicians
                .AsNoTracking()
                .OrderBy(t => t.Id)
                .Select(t => new TechnicianReadDto
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Phone = t.Phone,
                    Skill = t.Skill
                })
                .ToListAsync();
        }

        public async Task<TechnicianReadDto?> GetByIdAsync(int id)
        {
            return await _db.Technicians
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new TechnicianReadDto
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Phone = t.Phone,
                    Skill = t.Skill
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TechnicianReadDto> CreateAsync(TechnicianCreateDto dto)
        {
            var entity = new Models.Technician
            {
                FullName = dto.FullName.Trim(),
                Phone = dto.Phone?.Trim(),
                Skill = dto.Skill?.Trim()
            };

            _db.Technicians.Add(entity);
            await _db.SaveChangesAsync();

            return new TechnicianReadDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Phone = entity.Phone,
                Skill = entity.Skill
            };
        }

        public async Task<bool> UpdateAsync(int id, TechnicianUpdateDto dto)
        {
            var tech = await _db.Technicians.FirstOrDefaultAsync(t => t.Id == id);
            if (tech is null) return false;

            tech.FullName = dto.FullName.Trim();
            tech.Phone = dto.Phone?.Trim();
            tech.Skill = dto.Skill?.Trim();

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tech = await _db.Technicians.FirstOrDefaultAsync(t => t.Id == id);
            if (tech is null) return false;

            _db.Technicians.Remove(tech);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}

