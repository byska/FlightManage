using FlightManage.Application.Abstractions;
using FlightManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Infrastructure.Persistence
{
    public class FlightDbContext : DbContext, IUnitOfWork
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
        {
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<SharedFlight> SharedFlights { get; set; }
        public DbSet<ConnectingFlight> ConnectingFlights { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext).Assembly);
        }
    }
}
