using ActualLab.Fusion;
using Lift.Infrastructure;
using Lift.Models;

namespace Lift.Services
{
    public class ElevatorService : IComputeService
    {
        private readonly ElevatorDbContext _context;
        private readonly object _locker = new object();
        public ElevatorService(ElevatorDbContext context)
        {
            _context = context;
        }

        [ComputeMethod]
        public virtual Task<ElevatorState?> GetCurrentElevatorState()
        {
            lock (_locker)
            {
                var result = _context.ElevatorStates.OrderBy(e => e.Id).FirstOrDefault();

                return Task.FromResult(result);
            }
        }

        public Task RequestElevator(int targetFloor)
        {
            lock (_locker)
            {
                var request = new ElevatorRequest
                {
                    RequestedFloor = targetFloor,
                    RequestTime = DateTime.UtcNow.AddHours(5),
                };
                _context.ElevatorRequests.Add(request);
                _context.SaveChanges();

                var elevatorState = _context.ElevatorStates.OrderBy(e => e.Id).FirstOrDefault();
                if (elevatorState != null)
                {
                    elevatorState.Direction = elevatorState.CurrentFloor > targetFloor ? "Pastga" : "Tepaga";
                    elevatorState.CurrentFloor = targetFloor;
                    elevatorState.IsBusy = true;

                    _context.ElevatorStates.Update(elevatorState);
                    _context.SaveChanges();

                    elevatorState.IsBusy = false;

                    _context.ElevatorStates.Update(elevatorState);
                    _context.SaveChanges();
                }
            }

            using (Invalidation.Begin())
            {
                GetCurrentElevatorState();
            }

            return Task.CompletedTask;
        }

        public List<ElevatorRequest> GetElevatorRequests()
        {
            lock (_locker)
            {
                return _context.ElevatorRequests.OrderByDescending(r => r.RequestTime).ToList();
            }
        }
    }
}
