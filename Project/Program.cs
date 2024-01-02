using Microsoft.EntityFrameworkCore;
using System;
using Project;
using  Project.Models;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AirportContext>(options => options.UseSqlServer(connection));

var services = builder.Services;

builder.Services.AddTransient<Airline>();

builder.Services.AddDirectoryBrowser();

var app = builder.Build();

app.UseMiddleware<AirlineMiddleware>();


app.MapGet("/", (AirportContext db) => db.Airlines.ToList());

app.MapPost("/addAirline", ( string AirlineName,  int Plane_quont, int Route_quont, AirportContext db) =>
{
    Airline NewA = new Airline();
 
    NewA.AirlineName = AirlineName;
    NewA.Plane_quont = Plane_quont;
    NewA.Route_quont = Route_quont;
    db.Airlines.Add(NewA);
    db.SaveChanges();
    return NewA;
});


app.Run();