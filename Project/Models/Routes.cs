﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Routes
    {
        [Required]
        [Key]
        public int RouteId { get; set; }
        public double Distance { get; set; }
        [MaxLength(6)]
        [Required]
        public int Airport_ID_1 { get; set; }

        public Airport_ Airport_1 { get; set; }
        [MaxLength(6)]
        [Required]
        public int Airport_ID_2 { get; set; }
        public Airport_ Airport_2 { get; set; }
        [Required]
        public string Airline_name { get; set; }
        public Airline? Airline { get; set; }
        [ForeignKey("Airline_id")]
        public int? Airline_id { get; set; }

        public List<Flight> Flights { get; set; } = new();


    }
}
