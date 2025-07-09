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
    public class ConnectingFlightConfiguration : IEntityTypeConfiguration<ConnectingFlight>
    {
        public void Configure(EntityTypeBuilder<ConnectingFlight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Destination).IsRequired().HasMaxLength(150);
            builder.Property(x => x.DepartureTime).IsRequired();
            builder.HasOne(x => x.SharedFlight).WithOne(x => x.ConnectingFlight).HasForeignKey<ConnectingFlight>(x => x.SharedFlightId);
        }
    }
}
