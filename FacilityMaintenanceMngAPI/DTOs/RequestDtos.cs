using System.ComponentModel.DataAnnotations;
using FacilityMaintenanceMngAPI.Models;

namespace FacilityMaintenanceMngAPI.DTOs
{
    public class RequestCreateDto
    {
        [Required]
        public int FacilityId { get; set; }

        [Required, StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        
        public int? TechnicianId { get; set; }
    }

    public class RequestUpdateDto
    {
        // Allow status update
        [Required]
        public RequestStatus Status { get; set; }

        public int? TechnicianId { get; set; }
    }

    public class RequestReadDto
    {
        public int Id { get; set; }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; } = string.Empty;

        public int? TechnicianId { get; set; }
        public string? TechnicianName { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public RequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
