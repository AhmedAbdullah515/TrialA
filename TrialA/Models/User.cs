using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrialA.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,Employer,Candidate
    }
    public class User
    {
        public int UserId { get; set; }
        
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
        public CandidateProfile CandidateProfile { get; set; }
        public List<Company> Companies { get; set; }=new List<Company>();   
    }
}
