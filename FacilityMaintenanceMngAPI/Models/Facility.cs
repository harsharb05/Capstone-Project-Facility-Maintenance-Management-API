using System.ComponentModel.DataAnnotations;

namespace FacilityMaintenanceMngAPI.Models
{
    public class Facility
    {
      
            public int Id { get; set; }

            [Required]
            [StringLength(120)]
            public string Name { get; set; } = string.Empty;

            [Required]
            [StringLength(200)]
            public string Location { get; set; } = string.Empty;

           
            public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }
                = new List<MaintenanceRequest>();
        }
    
}
