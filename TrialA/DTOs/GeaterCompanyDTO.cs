using System.ComponentModel.DataAnnotations;

namespace TrialA.DTOs
{
    public class GeaterCompanyDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public int Jopscount {  get; set; }
    }
}
