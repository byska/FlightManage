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
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AircraftType).IsRequired();
            builder.Property(x => x.SeatCount).IsRequired();
            builder.Property(x => x.SeatPlan).IsRequired().HasMaxLength(50);
            builder.Property(x => x.MaxPassengers).IsRequired();
            builder.Property(x => x.MaxCrew).IsRequired();
            builder.Property(x => x.StandardMenu).IsRequired();
        }
    }
}
