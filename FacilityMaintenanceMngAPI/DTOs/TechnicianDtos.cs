using System.ComponentModel.DataAnnotations;

namespace FacilityMaintenanceMngAPI.DTOs
{
    public class TechnicianCreateDto
    {
        [Required, StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Phone, StringLength(25)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Skill { get; set; }
    }

    public class TechnicianUpdateDto
    {
        [Required, StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Phone, StringLength(25)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Skill { get; set; }
    }

    public class TechnicianReadDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Skill { get; set; }
    }
}

