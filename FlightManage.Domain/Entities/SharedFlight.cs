using FlightManage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
    public class SharedFlight : EntityBase
    {
        public FlightNumber PartnerFlightNumber { get; set; } // AANNNN
        public string PartnerCompany { get; set; }
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }
        public ConnectingFlight? ConnectingFlight { get; set; }

        protected SharedFlight()
        {
        }
        public static SharedFlight Create(Guid flightId, FlightNumber partnerFlightNumber, string partnerCompany)
        {
            if (!Regex.IsMatch(partnerFlightNumber, @"^[A-Z]{2}\d{4}$"))
                throw new ArgumentException("Partner flight number must be in format AANNNN.");

            if (string.IsNullOrWhiteSpace(partnerCompany))
                throw new ArgumentException("Partner company is required.");

            return new SharedFlight
            {
                PartnerFlightNumber = partnerFlightNumber,
                PartnerCompany = partnerCompany,
                FlightId = flightId,
                CreateDate = DateTime.UtcNow
            };
        }
        public void AddConnectingFlight(string destination, DateTime departureTime)
        {
            if (ConnectingFlight != null)
                throw new InvalidOperationException("Connecting flight already exists.");

            ConnectingFlight = new ConnectingFlight(this.Id, destination, departureTime);
        }
    }
}
