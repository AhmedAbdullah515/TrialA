using System.ComponentModel.DataAnnotations;

namespace TrialA.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public string? Website { get; set; }
        [Required]
        public string Location { get; set; }
        public User User { get; set; }
        public int UserId {  get; set; }
        public List<Jop> Jops { get; set; } = new List<Jop>();
    }
}
