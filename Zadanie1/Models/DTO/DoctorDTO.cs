using System.ComponentModel.DataAnnotations;

namespace Zadanie1.Models.DTO
{
    public class DoctorDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
