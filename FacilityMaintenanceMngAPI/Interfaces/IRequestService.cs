using FacilityMaintenanceMngAPI.DTOs;

namespace FacilityMaintenanceMngAPI.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestReadDto>> GetAllAsync();
        Task<RequestReadDto?> GetByIdAsync(int id);

     
        Task<RequestReadDto?> CreateAsync(RequestCreateDto dto);

       
        Task<RequestReadDto?> UpdateAsync(int id, RequestUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
