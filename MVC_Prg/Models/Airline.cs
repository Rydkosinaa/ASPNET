
using System.ComponentModel.DataAnnotations;

namespace MVS_Prg.Models
{
    public class Airline
    {
        [Key]
        public int Airline_id { get; set; }
        public string? AirlineName { get; set; }
        public int Plane_quont { get; set; }
        public int Route_quont { get; set; }
        public List<Plane> Plane{ get; set; } = new();  
        public List<Routes> Route{ get; set; } = new();

    }

}
