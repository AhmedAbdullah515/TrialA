using System.ComponentModel.DataAnnotations;
using TrialA.Models;

namespace TrialA.DTOs
{
    public class UpdateCandidateProfiles
    {
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string? ResumeUrl { get; set; }
        [Required]
        [MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int YearOfExperience { get; set; }
        public int UserId { get; set; }
    }
}
