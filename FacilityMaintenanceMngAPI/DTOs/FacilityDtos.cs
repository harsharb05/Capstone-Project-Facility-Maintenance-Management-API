using System.ComponentModel.DataAnnotations;

namespace FacilityMaintenanceMngAPI.DTOs
{
    public class FacilityCreateDto
    {
        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;
    }

    public class FacilityUpdateDto
    {
        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Location { get; set; } = string.Empty;
    }

    public class FacilityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
