using FlightManage.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Application.UseCases.FlightUseCases.Queries
{
    public class GetByIdFlightsQueryRequest : IRequest<GetByIdFlightsQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdFlightsQueryRequest(Guid ıd)
        {
            Id = ıd;
        }
    }

    public class GetByIdFlightsQueryResponse
    {
        public string FlightNumber { get; set; }
        public DateTime FlightDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        public FlightRouteResponse FlightRoute { get; set; }
        public VehicleTypeResponse VehicleType { get; set; }
        public SharedFlightResponse SharedFlight { get; set; }

    }

    public class GetByIdFlightsHandler : IRequestHandler<GetByIdFlightsQueryRequest, GetByIdFlightsQueryResponse>
    {
        private readonly IFlightRepository _repo;

        public GetByIdFlightsHandler(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<GetByIdFlightsQueryResponse> Handle(GetByIdFlightsQueryRequest request, CancellationToken cancellationToken)
        {
            var flights = await _repo.GetByIdAsync(request.Id, cancellationToken);
            if (flights is null) return null;
            return new GetByIdFlightsQueryResponse
            {
                FlightNumber = flights.FlightNumber.Value,
                FlightDateTime = flights.FlightDateTime,
                Duration = flights.Duration,
                Distance = flights.Distance,

                FlightRoute = flights.FlightRoute == null ? null : new FlightRouteResponse
                {
                    SourceAirport = flights.FlightRoute.SourceAirport == null ? null : new AirportResponse
                    {
                        Country = flights.FlightRoute.SourceAirport.Country,
                        City = flights.FlightRoute.SourceAirport.City,
                        Name = flights.FlightRoute.SourceAirport.Name,
                        Code = flights.FlightRoute.SourceAirport.Code
                    },
                    DestinationAirport = flights.FlightRoute.DestinationAirport == null ? null : new AirportResponse
                    {
                        Country = flights.FlightRoute.DestinationAirport.Country,
                        City = flights.FlightRoute.DestinationAirport.City,
                        Name = flights.FlightRoute.DestinationAirport.Name,
                        Code = flights.FlightRoute.DestinationAirport.Code
                    },
                    RouteType = flights.FlightRoute.RouteType.ToString()
                },

                VehicleType = flights.VehicleType == null ? null : new VehicleTypeResponse
                {
                    AircraftType = flights.VehicleType.AircraftType.ToString(),
                    SeatCount = flights.VehicleType.SeatCount,
                    SeatPlan = flights.VehicleType.SeatPlan.ToString(),
                    MaxPassengers = flights.VehicleType.MaxPassengers,
                    MaxCrew = flights.VehicleType.MaxCrew,
                    StandardMenu = flights.VehicleType.StandardMenu
                },

                SharedFlight = flights.SharedFlight == null ? null : new SharedFlightResponse
                {
                    PartnerFlightNumber = flights.SharedFlight.PartnerFlightNumber,
                    PartnerCompany = flights.SharedFlight.PartnerCompany,
                    FlightId = flights.SharedFlight.FlightId,

                }
            };
        }
    }

}
