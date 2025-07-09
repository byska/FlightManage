using FlightManage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
    public class Flight : EntityBase
    {
        public FlightNumber FlightNumber { get; private set; }
        public DateTime FlightDateTime { get; private set; }
        public FlightDuration Duration { get; private set; }
        public double Distance { get; private set; }

        public Guid FlightRouteId { get; set; }
        public FlightRoute FlightRoute { get; set; }

        public Guid VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public SharedFlight? SharedFlight { get; set; }
        protected Flight()
        {

        }
        public static Flight Create(
           FlightNumber flightNumber,
           DateTime flightDate,
           FlightDuration duration,
           double distance,
           FlightRoute route,
           VehicleType vehicle)
        {
            if (string.IsNullOrWhiteSpace(flightNumber) || !Regex.IsMatch(flightNumber, @"^[A-Z]{2}\d{4}$"))
                throw new ArgumentException("Invalid flight number format.");

            return new Flight
            {
                Id = Guid.NewGuid(),
                FlightNumber = flightNumber,
                FlightDateTime = flightDate,
                Duration = duration,
                Distance = distance,
                FlightRoute = route,
                VehicleType = vehicle,
                CreateDate = DateTime.UtcNow
            };
        }
        public void AddSharedFlight(FlightNumber partnerFlightNumber, string partnerCompany)
        {
            if (SharedFlight != null)
                throw new InvalidOperationException("Shared flight already exists.");

            SharedFlight = SharedFlight.Create(this.Id, partnerFlightNumber, partnerCompany);
        }

        public void AddConnectingFlightToShared(string destination, DateTime departureTime)
        {
            if (SharedFlight == null)
                throw new InvalidOperationException("Cannot add connecting flight before shared flight.");

            SharedFlight.AddConnectingFlight(destination, departureTime);
        }

        public bool IsShared => SharedFlight != null;
    }
}
