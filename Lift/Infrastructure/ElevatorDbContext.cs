using ActualLab.Fusion.Authentication.Services;
using ActualLab.Fusion.EntityFramework.Operations;
using Lift.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<DbUser<string>> Users { get; protected set; } = null!;
        public DbSet<DbUserIdentity<string>> UserIdentities { get; protected set; } = null!;
        public DbSet<DbSessionInfo<string>> Sessions { get; protected set; } = null!;

        public DbSet<DbOperation> Operations { get; protected set; } = null!;
        public DbSet<DbEvent> Events { get; protected set; } = null!;
    }
}
