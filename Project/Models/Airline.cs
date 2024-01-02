
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Airline
    {
        [Required]
        [Key]
        public int Airline_id { get; set; }
        public string? AirlineName { get; set; }
        public int Plane_quont { get; set; }
        public int Route_quont { get; set; }
        public List<Plane> Plane{ get; set; } = new();  
        public List<Routes> Route{ get; set; } = new();

    
    }

}
