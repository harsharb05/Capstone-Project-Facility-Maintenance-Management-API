using FacilityMaintenanceMngAPI.DTOs;

namespace FacilityMaintenanceMngAPI.Interfaces
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityReadDto>> GetAllAsync();
        Task<FacilityReadDto?> GetByIdAsync(int id);

        Task<FacilityReadDto> CreateAsync(FacilityCreateDto dto);
        Task<bool> UpdateAsync(int id, FacilityUpdateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<RequestReadDto>?> GetRequestsForFacilityAsync(int facilityId);
    }
}

