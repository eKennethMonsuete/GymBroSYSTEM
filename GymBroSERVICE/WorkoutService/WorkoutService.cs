using GymBroINFRA.Entity;
using GymBroINFRA.Repository;

namespace GymBroSERVICE.WorkoutService
{
    public class WorkoutService : IWorkoutService
    {

        private readonly IRepository<Workout> _repository;

        public WorkoutService(IRepository<Workout> repository)
        {
            _repository = repository;
        }
    }
}
