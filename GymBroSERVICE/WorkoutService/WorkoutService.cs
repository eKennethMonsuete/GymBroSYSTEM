using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.WorkoutService.DTO.Response;

namespace GymBroSERVICE.WorkoutService
{
    public class WorkoutService : IWorkoutService
    {

        private readonly IRepository<Workout> _repository;

        public WorkoutService(IRepository<Workout> repository)
        {
            _repository = repository;
        }

        public async Task<List<WorkoutFindAllResponse>> FindAll()
        {
            var workoutEntity = await _repository.GetAllAsync();

            var workoutDTO = workoutEntity.Select(x => new WorkoutFindAllResponse
            {
                Id = x.Id,
                WorkoutName = x.WorkoutName,
                Exercise = x.Exercise,
                Description = x.Description,
                Note = x.Note,
                CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
            }).ToList();
            return  workoutDTO;
            
        }
    }
}
