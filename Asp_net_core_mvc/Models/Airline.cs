
using System.ComponentModel.DataAnnotations;
using Asp_net_core_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Asp_net_core_mvc.Models
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


public static class AirlineEndpoints
{
	public static void MapAirlineEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Airline", async (Asp_net_core_mvcContext db) =>
        {
            return await db.Airlines.ToListAsync();
        })
        .WithName("GetAllAirlines")
        .Produces<List<Airline>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Airline/{id}", async (int Airline_id, Asp_net_core_mvcContext db) =>
        {
            return await db.Airlines.FindAsync(Airline_id)
                is Airline model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetAirlineById")
        .Produces<Airline>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Airline/{id}", async (int Airline_id, Airline airline, Asp_net_core_mvcContext db) =>
        {
            var foundModel = await db.Airlines.FindAsync(Airline_id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(airline);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateAirline")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Airline/", async (Airline airline, Asp_net_core_mvcContext db) =>
        {
            db.Airlines.Add(airline);
            await db.SaveChangesAsync();
            return Results.Created($"/Airlines/{airline.Airline_id}", airline);
        })
        .WithName("CreateAirline")
        .Produces<Airline>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Airline/{id}", async (int Airline_id, Asp_net_core_mvcContext db) =>
        {
            if (await db.Airlines.FindAsync(Airline_id) is Airline airline)
            {
                db.Airlines.Remove(airline);
                await db.SaveChangesAsync();
                return Results.Ok(airline);
            }

            return Results.NotFound();
        })
        .WithName("DeleteAirline")
        .Produces<Airline>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
}
