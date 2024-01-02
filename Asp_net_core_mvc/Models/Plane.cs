
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_net_core_mvc.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public Airline? AirlineId { get; set; }
        [ForeignKey("Airline_id")]
        public int? Airline_id { get; set; }

        public string Airline_Name { get; set; }
        [MaxLength(6)]
        [Required]
        public Airline? Airline { get; set; }
        [Required]
        public int Flight_Id { get; set; }
        public List<Flight> Flight { get; set; } = new();
        public int Max_Plane_Quont { get; set; }
        
        [Required(ErrorMessage = "Не встановлена кількість пілотів")]
        [Range(0, 5, ErrorMessage = "Кількість пілотів повинна бути в діапазоні 1-5")]
        public int Pilote_Quont { get; set; }
        public int Flight_Attendant_Quont { get; set; } 
        public double Carrying_Capacity { get; set; }  
        public double Fuel_Consumption { get; set; }

        public static implicit operator int(Plane? v)
        {
            throw new NotImplementedException();
        }
    }
}
