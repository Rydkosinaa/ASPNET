
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVS_Prg.Models
{
    public class Airport_
    {

        [MaxLength(6)]
        [Required]

        public int Airport_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Workers_quont { get; set; }
        public int Passengers_quont { get; set; }
        public int Planes_quont { get; set; }
        public int Gates_quont { get; set; }
        [NotMapped]
        public List<Worker> Worker { get; set; } = new();
        [NotMapped]
        public List<Routes> Route1 { get; set; } = new();
        [NotMapped]
        public List<Routes> Route2 { get; set; } = new();
        [NotMapped]
        public virtual List<Worker> Workers { get; set; } = new();

    }
}
