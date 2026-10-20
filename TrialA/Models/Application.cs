using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace TrialA.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum ApplicationStatus
    {
        Pending,UnderReview,Accepted,Rejected
    }
    public class Application
    {
        public int ApplicationId { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public ApplicationStatus Status { get; set; }
        [MaxLength(2000)]
        public string  ?CoverLetter { get; set; }
        public int CandidateProfileId { get; set; }
        public CandidateProfile CandidateProfile { get; set; }
        public int JopId {  get; set; }
        public Jop Jop { get; set; }
    }
}
