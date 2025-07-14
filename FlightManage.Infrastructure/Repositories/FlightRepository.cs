using FlightManage.Application.Abstractions;
using FlightManage.Domain.Entities;
using FlightManage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDbContext _flightContext;
        public FlightRepository(FlightDbContext flightContext) => _flightContext = flightContext;

        public async Task<IReadOnlyList<Flight>> GetAllAsync(CancellationToken ct)
        {
            return await _flightContext.Flights.Include(x => x.FlightRoute).ThenInclude(x => x.SourceAirport).Include(x => x.FlightRoute)
            .ThenInclude(x => x.DestinationAirport).Include(x => x.VehicleType).Include(x => x.SharedFlight).AsNoTracking().Where(x=>x.IsActive).ToListAsync(ct);

        }

        public async Task<Flight> GetByIdAsync(Guid id, CancellationToken ct)
        {
            Flight? flight = await _flightContext.Flights.Include(x => x.FlightRoute).ThenInclude(x => x.SourceAirport).Include(x => x.FlightRoute)
            .ThenInclude(x => x.DestinationAirport).Include(x => x.VehicleType).Include(x => x.SharedFlight).Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync(ct);
            return flight;
        }
        public async Task<Flight> GetByFlightNumberAsync(string flightNumber, CancellationToken ct)
        {
            try
            {
                Flight? flight = await _flightContext.Flights.Include(x => x.FlightRoute).ThenInclude(x => x.SourceAirport).Include(x => x.FlightRoute)
           .ThenInclude(x => x.DestinationAirport).Include(x => x.VehicleType).Include(x => x.SharedFlight).Where(x => x.FlightNumber.Value == flightNumber && x.IsActive).FirstOrDefaultAsync(ct);
                return flight;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
