
using System.ComponentModel.DataAnnotations;

namespace MVS_Prg.Models
{
    public class Passenger : Human
    {
        [MaxLength(6)]
        [Required]
        public int PassengerId { get; set; }
        public int Age { get; set; }
        public List <Ticket> Tickets {get; set; }

    }
}
