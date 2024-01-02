using System;
using Newtonsoft.Json;
using Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Project;

public class AirlineMiddleware
{
    private readonly RequestDelegate _next;

    public AirlineMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AirportContext db)
    {
    


        if (context.Request.Method == "GET")
        {
            if (context.Request.Path == "/Airline" && context.Request.Query.ContainsKey("Airline_id"))
            {
                if (int.TryParse(context.Request.Query["Airline_Id"], out int AirlineId))
                {
                    Airline? found_airline = await db.Airlines.FirstOrDefaultAsync(u => u.Airline_id == AirlineId);
                    if (found_airline != null)
                    {
                        context.Response.StatusCode = 200;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(found_airline));
                        return;
                    }
                }
            }
            else
            {
                await _next(context);
            }

        }
        if (context.Request.Method == "POST")
        {
            if (context.Request.Path == "/Test" )
            {

            }
            else
            {
                await _next(context);
            }
        }


    }
}