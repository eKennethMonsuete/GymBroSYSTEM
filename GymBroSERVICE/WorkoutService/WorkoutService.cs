using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.WorkoutService.DTO.Request;
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
        
        public async Task<WorkoutFindAllResponse> Create(WorkoutCreateRequest workoutInput)
        {
            if(workoutInput == null) throw new ArgumentNullException("O treino não podem ser null.");


            var WorkoutToSave = new Workout { 
                WorkoutName = workoutInput.WorkoutName,
                Exercise = workoutInput.Exercise, Description = workoutInput.Description,
                Note = workoutInput.Note,
                StudentId = workoutInput.StudentId,
            };   

            if(workoutInput.StudentId == null)
            {
                throw new ArgumentNullException("o id do aluno não pode ser null");
            }

            var result =  _repository.Create(WorkoutToSave);

            return new WorkoutFindAllResponse
            {
                Id = result.Id,
                WorkoutName = result.WorkoutName,
                Exercise = result.Exercise,
                Description = result.Description,
                Note = result.Note,
                CreatedAt = result.CreatedAt.ToString("dd/MM/yyyy"),
                StudentId = result.StudentId,
            };
            
                
         
        }

        public WorkoutFindAllResponse Update(WorkoutUpdateRequest workoutUpdate, long id)
        {
            if (workoutUpdate == null) throw new ArgumentNullException(" O treino não pode ser null");

            var existingWorkout = _repository.FindByID(id);

            if (existingWorkout == null)
                {
                throw new ArgumentNullException(" O treino não foi encontrado");
            }

            existingWorkout.WorkoutName = workoutUpdate.WorkoutName;
            existingWorkout.Exercise = workoutUpdate.Exercise;
            existingWorkout.Note = workoutUpdate.Note;
            existingWorkout.Description= workoutUpdate.Description;
            existingWorkout.StudentId = workoutUpdate.StudentId;

            var updatedWorkout = _repository.Update(existingWorkout);

            var updatedWorkoutDTO = new WorkoutFindAllResponse
            {
                Id = updatedWorkout.Id,
                WorkoutName = updatedWorkout.WorkoutName,
                Exercise = updatedWorkout.Exercise,
                Description = updatedWorkout.Description,
                Note = updatedWorkout.Note,
                StudentId = updatedWorkout.StudentId,
            };

            return updatedWorkoutDTO;
                

        }

        public WorkoutFindAllResponse FindById(long id)
        {
            try
            {
                var workout = _repository.FindByID(id);

                // Verifica se a medida foi encontrada
                if (workout == null)
                {
                    throw new KeyNotFoundException($"Treino com o ID {id} não foi encontrada.");
                }

                // Mapeia a entidade para o DTO
                var responseDTO = new WorkoutFindAllResponse
                {
                    Id= workout.Id,
                    WorkoutName= workout.WorkoutName,
                    Exercise = workout.Exercise,
                    Description = workout.Description,

                    StudentId = workout.StudentId,
                    Note = workout.Note
                };

                return responseDTO;
            }
            catch (KeyNotFoundException ex)
            {
                // Tratamento específico para o caso de medida não encontrada
                Console.WriteLine($"Error: {ex.Message}");
                throw;  // Propaga a exceção para que a camada superior possa lidar com ela
            }
            catch (Exception ex)
            {
                // Tratamento para exceções genéricas
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw new Exception("Ocorreu um erro ao buscar a medida. Tente novamente mais tarde.");
            }
        }
    }
}
