using FlightManage.Domain.Entities;
using FlightManage.Domain.Enums;
using FlightManage.Domain.ValueObjects;
using FlightManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Infrastructure.Seed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new FlightDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<FlightDbContext>>());

            if (context.Airports.Any()) return;

            var aircraft = new VehicleType
            {
                Id = Guid.NewGuid(),
                AircraftType = AircraftType.AirbusA320,
                SeatCount = 180,
                SeatPlan = SeatPlan.ThreeThree,
                MaxPassengers = 180,
                MaxCrew = 6,
                StandardMenu = "Standart"
            };

            var ist = new Airport("Türkiye", "İstanbul", "İstanbul Havalimanı", new AirportCode("IST"));
            var esb = new Airport("Türkiye", "Ankara", "Esenboğa Havalimanı", new AirportCode("ESB"));

            var route = new FlightRoute
            {
                Id = Guid.NewGuid(),
                SourceAirport = ist,
                DestinationAirport = esb
            };

            var flight1 = Flight.Create(
                new FlightNumber("TK1234"),
                DateTime.UtcNow.AddDays(2),
                new FlightDuration(TimeSpan.FromMinutes(75)),
                450.0,
                route,
                aircraft
            );
            flight1.AddSharedFlight(new FlightNumber("LH5678"), "Lufthansa");
            flight1.AddConnectingFlightToShared("Berlin", DateTime.UtcNow.AddDays(2).AddHours(3));

            var flight2 = Flight.Create(
                new FlightNumber("TK5678"),
                DateTime.UtcNow.AddDays(3),  
                new FlightDuration(TimeSpan.FromMinutes(90)),
                550.0,
                route,
                aircraft
            );
            flight2.AddSharedFlight(new FlightNumber("AF9876"), "Air France");
            flight2.AddConnectingFlightToShared("Paris", DateTime.UtcNow.AddDays(3).AddHours(2));

            context.VehicleTypes.Add(aircraft);
            context.Airports.AddRange(ist, esb);
            context.FlightRoutes.Add(route);
            context.Flights.AddRange(flight1, flight2);
            context.SaveChanges();
        }

    }
}
