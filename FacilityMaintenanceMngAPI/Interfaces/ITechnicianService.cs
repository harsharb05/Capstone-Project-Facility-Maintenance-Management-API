using FacilityMaintenanceMngAPI.DTOs;

namespace FacilityMaintenanceMngAPI.Interfaces
{
    public interface ITechnicianService
    {
        Task<IEnumerable<TechnicianReadDto>> GetAllAsync();
        Task<TechnicianReadDto?> GetByIdAsync(int id);

        Task<TechnicianReadDto> CreateAsync(TechnicianCreateDto dto);
        Task<bool> UpdateAsync(int id, TechnicianUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
