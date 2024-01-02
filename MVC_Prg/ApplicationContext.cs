using MVS_Prg.Models;
using Microsoft.EntityFrameworkCore;

namespace MVS_Prg
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Airport_> Airport_s { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Routes> Routes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Worker> Workers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>().HasData(
                    new Airline { Airline_id = 1, AirlineName = "Airline1", Plane_quont = 1, Route_quont = 1 },
                    new Airline { Airline_id = 2, AirlineName = "Airline2", Plane_quont = 2, Route_quont = 1 },
                    new Airline { Airline_id = 3, AirlineName = "Airline3", Plane_quont = 3, Route_quont = 3 },
                   new Airline { Airline_id = 4, AirlineName = "Airline4", Plane_quont = 4, Route_quont = 1 }
            );



            modelBuilder.Entity<Airline>().Property(a => a.AirlineName).HasMaxLength(50);
            modelBuilder.Entity<Airline>().Property(a => a.AirlineName).IsRequired();

            //    modelBuilder.Entity<Passenger>().HasCheckConstraint("Age", "Age > 0 AND Age < 100");

            modelBuilder.Entity<Worker>().HasKey(i => new { i.WorkerId, i.Surname });

            modelBuilder.Entity<Airport_>().HasAlternateKey(i => new { i.Name, i.Address });

            modelBuilder.Entity<Ticket>().HasOne(t => t.Passenger).WithMany(p => p.Tickets).HasForeignKey(t => t.Passenger_Doc_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>().HasOne(t => t.Flight).WithMany(f => f.Ticket).HasForeignKey(t => t.Flight_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Routes>().HasOne(r => r.Airport_1).WithMany(a => a.Route1).HasForeignKey(r => r.Airport_ID_1).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Routes>().HasOne(r => r.Airport_2).WithMany(a => a.Route2).HasForeignKey(r => r.Airport_ID_2).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Routes>().HasMany(r => r.Flights).WithOne(f => f.Route).HasForeignKey(f => f.Route_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Routes>().HasOne(r => r.Airline).WithMany(a => a.Route).HasForeignKey(r => r.Airline_id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>().HasMany(f => f.Ticket).WithOne(t => t.Flight).HasForeignKey(t => t.Flight_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>().HasOne(f => f.Plane).WithMany(p => p.Flight).HasForeignKey(f => f.Plane_Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>().HasOne(f => f.Route).WithMany(r => r.Flights).HasForeignKey(f => f.Route_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Plane>().HasOne(p => p.Airline).WithMany(a => a.Plane).HasForeignKey(p => p.Airline_id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Plane>().HasMany(p => p.Flight).WithOne(f => f.Plane).HasForeignKey(f => f.Plane_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Airline>().HasMany(a => a.Plane).WithOne(p => p.Airline).HasForeignKey(p => p.Airline_id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Airline>().HasMany(a => a.Route).WithOne(r => r.Airline).HasForeignKey(r => r.Airline_id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Worker>().HasOne(w => w.Airport).WithMany(a => a.Worker).HasForeignKey(w => w.AirportId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Airport_>().HasMany(a_ => a_.Route1).WithOne(r => r.Airport_1).HasForeignKey(r => r.Airport_ID_1).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Airport_>().HasMany(a_ => a_.Route2).WithOne(r => r.Airport_2).HasForeignKey(r => r.Airport_ID_2).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Airport_>().HasMany(a_ => a_.Worker).WithOne(w => w.Airport).HasForeignKey(r => r.AirportId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Passenger>().HasMany(p => p.Tickets).WithOne(t => t.Passenger).HasForeignKey(t => t.Passenger_Doc_Id).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Airport_>().HasAlternateKey(i => new { i.Name, i.Address });
            modelBuilder.Entity<Worker>().HasKey(i => new { i.WorkerId, i.Surname });

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { PassengerId = 1, Age = 20, Name = "Passenger1", Surname = "Surname1" },
                new Passenger { PassengerId = 2, Age = 20, Name = "Passenger2", Surname = "Surname2" },
                new Passenger { PassengerId = 3, Age = 21, Name = "Passenger3", Surname = "Surname3" },
                new Passenger { PassengerId = 4, Age = 25, Name = "Passenger4", Surname = "Surname4" },
                new Passenger { PassengerId = 5, Age = 30, Name = "Passenger5", Surname = "Surname5" }

                );
            modelBuilder.Entity<Plane>().HasData(
              new Plane { PlaneId = 1, Airline_id = 1, Airline_Name = "Airline1", Flight_Id = 1, Max_Plane_Quont = 100, Pilote_Quont = 2, Flight_Attendant_Quont = 3, Carrying_Capacity = 300, Fuel_Consumption = 200 },
              new Plane { PlaneId = 2, Airline_id = 2, Airline_Name = "Airline2", Flight_Id = 2, Max_Plane_Quont = 200, Pilote_Quont = 2, Flight_Attendant_Quont = 30, Carrying_Capacity = 300, Fuel_Consumption = 200 },
              new Plane { PlaneId = 3, Airline_id = 1, Airline_Name = "Airline3", Flight_Id = 1, Max_Plane_Quont = 100, Pilote_Quont = 2, Flight_Attendant_Quont = 3, Carrying_Capacity = 300, Fuel_Consumption = 200 },
              new Plane { PlaneId = 4, Airline_id = 2, Airline_Name = "Airline1", Flight_Id = 1, Max_Plane_Quont = 100, Pilote_Quont = 2, Flight_Attendant_Quont = 3, Carrying_Capacity = 300, Fuel_Consumption = 200 }
       );
        }

    }
}
