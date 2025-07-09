using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
 
        public class ConnectingFlight : EntityBase
        {
            public string Destination { get; set; }
            public DateTime DepartureTime { get; set; }

            public Guid SharedFlightId { get; set; }
            public SharedFlight SharedFlight { get; set; }
            private ConnectingFlight() { }

            public ConnectingFlight(Guid sharedFlightId, string destination, DateTime departureTime)
            {
                if (string.IsNullOrWhiteSpace(destination))
                    throw new ArgumentException("Destination is required.");

                if (departureTime < DateTime.UtcNow)
                    throw new ArgumentException("Departure time must be in the future.");

                SharedFlightId = sharedFlightId;
                DepartureTime = departureTime;
                Destination = destination;
                CreateDate = DateTime.UtcNow;
            }
        
    }
}
