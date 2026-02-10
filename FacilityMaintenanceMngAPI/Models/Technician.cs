using System.ComponentModel.DataAnnotations;

namespace FacilityMaintenanceMngAPI.Models
{
    public class Technician
    {
            public int Id { get; set; }

            [Required]
            [StringLength(120)]
            public string FullName { get; set; } = string.Empty;

            [Phone]
            [StringLength(25)]
            public string? Phone { get; set; }

            [StringLength(100)]
            public string? Skill { get; set; }

         
            public ICollection<MaintenanceRequest> AssignedRequests { get; set; }
                = new List<MaintenanceRequest>();
        }
    
}
