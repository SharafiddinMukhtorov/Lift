using Lift.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lift.Infrastructure
{
    public class ElevatorDbContext : DbContext
    {
        public ElevatorDbContext(DbContextOptions<ElevatorDbContext> options)
        : base(options)
        {
        }

        public DbSet<ElevatorState> ElevatorStates { get; set; }
        public DbSet<ElevatorRequest> ElevatorRequests { get; set; }
    }
}
