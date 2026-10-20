using System.ComponentModel.DataAnnotations;
using TrialA.Models;

namespace TrialA.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100), MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public DateTime CeratedAt { get; set; }
    }
}
