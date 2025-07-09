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

            var flight = Flight.Create(
                new FlightNumber("TK1234"),
                DateTime.UtcNow.AddDays(2),
                new FlightDuration(TimeSpan.FromMinutes(75)),
                450.0,
                route,
                aircraft
                );
            flight.AddSharedFlight(new FlightNumber("LH5678"), "Lufthansa");

            flight.AddConnectingFlightToShared("Berlin", DateTime.UtcNow.AddDays(2).AddHours(3));

            context.VehicleTypes.Add(aircraft);
            context.Airports.AddRange(ist, esb);
            context.FlightRoutes.Add(route);
            context.Flights.Add(flight);
            context.SaveChanges();
        }
    }
}
