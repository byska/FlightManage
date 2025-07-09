using FlightManage.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
    public class FlightRoute : EntityBase
    {
        public Guid SourceAirportId { get; set; }
        public Airport SourceAirport { get; set; }

        public Guid DestinationAirportId { get; set; }
        public Airport DestinationAirport { get; set; }
        public RouteType RouteType { get; set; }

        public FlightRoute()
        {
        }
    }
}
