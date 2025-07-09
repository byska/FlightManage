using FlightManage.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Infrastructure.Persistence.Configurations
{
    public class FlightRouteConfiguration : IEntityTypeConfiguration<FlightRoute>
    {
        public void Configure(EntityTypeBuilder<FlightRoute> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SourceAirport).WithMany().HasForeignKey(x => x.SourceAirportId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DestinationAirport).WithMany().HasForeignKey(x => x.DestinationAirportId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
