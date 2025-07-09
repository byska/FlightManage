using FlightManage.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
    public class VehicleType : EntityBase
    {
        public AircraftType AircraftType { get; set; }
        public int SeatCount { get; set; }
        public SeatPlan SeatPlan { get; set; }

        public int MaxPassengers { get; set; }
        public int MaxCrew { get; set; }
        public string StandardMenu { get; set; }

        public VehicleType()
        {
        }
    }
}
