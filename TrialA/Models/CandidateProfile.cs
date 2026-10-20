using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TrialA.Models
{
    public class CandidateProfile
    {
        public int CandidateProfileId { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string? ResumeUrl { get; set; }
        [Required]
        [MaxLength(500)]
        public string Skill { get; set; }
        [Range(0,50)]
        public int YearOfExperience { get; set; }
        public User User { get; set; }
        public int UserId {  get; set; }
        public List<Application> Applications { get; set; } = new List<Application>();

    }
}
