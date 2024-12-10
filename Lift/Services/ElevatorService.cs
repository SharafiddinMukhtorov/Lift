using ActualLab.CommandR;
using ActualLab.CommandR.Configuration;
using ActualLab.Fusion;
using ActualLab.Fusion.EntityFramework;
using Lift.Infrastructure;
using Lift.Interface;
using Lift.Models;
using Microsoft.EntityFrameworkCore;
using System.Reactive;

namespace Lift.Services
{
    public class ElevatorService : DbServiceBase<ElevatorDbContext>, IElevatorService
    {
        public ElevatorService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [ComputeMethod]
        public virtual async Task<ElevatorState?> GetCurrentElevatorStateAsync(CancellationToken cancellation = default)
        {
            var _context = await DbHub.CreateDbContext(cancellation).ConfigureAwait(false);

            if (_context == null)
            {
                throw new Exception("DbContext yaratishda xato yuz berdi.");
            }

            var result = await _context.ElevatorStates
                .OrderBy(e => e.Id)
                .FirstOrDefaultAsync(cancellation);

            return result;
        }

        [CommandHandler]
        public virtual async Task RequestElevator(CommandForAdd command, CancellationToken cancellationToken = default)
        {
            var _context = await DbHub.CreateOperationDbContext(cancellationToken).ConfigureAwait(false);
            await using var _1 = _context.ConfigureAwait(false);

            int targetFloor = command.targetFloor;

            var elevatorState = _context.ElevatorStates.OrderBy(e => e.Id).FirstOrDefault();
            if (elevatorState != null)
            {
                elevatorState.Direction = elevatorState.CurrentFloor > targetFloor ? "Pastga" : "Tepaga";
                elevatorState.CurrentFloor = targetFloor;
                elevatorState.IsBusy = false;

                _context.ElevatorStates.Update(elevatorState);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            using (Invalidation.Begin())
            {
                await GetCurrentElevatorStateAsync(cancellationToken);
            }
        }

        public List<ElevatorRequest> GetElevatorRequests(CancellationToken cancellationToken)
        {
            var _context = DbHub.CreateOperationDbContext(cancellationToken);

            //return _context.ElevatorRequests.OrderByDescending(r => r.RequestTime).ToList();
            return null;
        }
    }
    public record CommandForAdd(int targetFloor) : ICommand<Unit>;
}
