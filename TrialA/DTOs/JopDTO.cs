using System.ComponentModel.DataAnnotations;
using TrialA.Models;

namespace TrialA.DTOs
{
    public class JopDTO
    {
        public int JopId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal Salary { get; set; }
        [Required]
        public EmployerType EmployeType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public Status Status { get; set; }
        public int CompanyId { get; set; }

    }
}
