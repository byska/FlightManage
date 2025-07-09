using FlightManage.Application.Abstractions;
using FlightManage.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManage.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightDbContext _context;

        public UnitOfWork(FlightDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
