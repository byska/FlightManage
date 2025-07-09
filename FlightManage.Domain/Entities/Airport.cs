using FlightManage.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Domain.Entities
{
 
        public class Airport : EntityBase
        {
            public string Country { get; set; }
            public string City { get; set; }
            public string Name { get; set; }
            public AirportCode Code { get; set; }
            public Airport(string country, string city, string name, AirportCode code)
            {

                Country = country;
                City = city;
                Name = name;
                Code = code;
            }
            protected Airport()
            {
            }
        }
    
}
