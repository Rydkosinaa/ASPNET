
using System.ComponentModel.DataAnnotations;

namespace MVS_Prg.Models
{
    public class Worker : Human
    {
    
        public int WorkerId { get; set; }
        [Required]
        public int AirportId { get; set; }
        public Airport_ Airport { get; set; } 
        public int Salary { get; set; }
        public string Position { get; set; }
        public virtual Airport_? Airports { get; set; }
    }
}
