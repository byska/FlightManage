using FlightManage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Application.Abstractions
{
    public interface IFlightRepository
    {
        Task<IReadOnlyList<Flight>> GetAllAsync(CancellationToken ct);
        Task<Flight> GetByIdAsync(Guid id, CancellationToken ct);
        Task<Flight> GetByFlightNumberAsync(string flightNumber, CancellationToken ct);
    }
}
