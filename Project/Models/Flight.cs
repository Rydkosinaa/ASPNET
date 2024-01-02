
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Flight
    {
        [MaxLength(6)]
        [Required]
        public int FlightId { get; set; }
        [MaxLength(6)]
        [Required]
        public int Plane_Id { get; set; }
        public Plane Plane { get; set; }
        [MaxLength(6)]
        [Required]
        public int Route_Id { get; set; }
        public Routes Route { get; set; }
        public DateTime First { get; set; }
        public DateTime Second { get; set; }

        public int Gate_Number { get; set; }    
        public int Pasengers_Quont { get; set; }
        public List<Ticket> Ticket { get; set; } = new(); 

    }
}
