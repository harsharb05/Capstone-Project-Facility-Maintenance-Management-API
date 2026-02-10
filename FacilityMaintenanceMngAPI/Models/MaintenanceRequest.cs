using System.ComponentModel.DataAnnotations;

namespace FacilityMaintenanceMngAPI.Models
{
    public class MaintenanceRequest
    {
        
            public int Id { get; set; }

            [Required]
            [StringLength(120)]
            public string Title { get; set; } = string.Empty;

            [StringLength(1000)]
            public string? Description { get; set; }

            [Required]
            public RequestStatus Status { get; set; } = RequestStatus.Open;

           
            [Required]
            public int FacilityId { get; set; }

            public Facility? Facility { get; set; }

          
            public int? TechnicianId { get; set; }

            public Technician? Technician { get; set; }

           
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        }
    
}
