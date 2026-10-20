using System.ComponentModel.DataAnnotations;
using TrialA.Models;

namespace TrialA.DTOs
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public ApplicationStatus Status { get; set; }
        [MaxLength(2000)]
        public string? CoverLetter { get; set; }
        public int CandidateProfileId { get; set; }
        public int JopId { get; set; }
    }
}
