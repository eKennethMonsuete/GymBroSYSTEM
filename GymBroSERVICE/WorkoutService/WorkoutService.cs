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
                StudentId = x.StudentId,
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
                CreatedAt = existingWorkout.CreatedAt.ToString("dd/MM/yyyy"),
                WorkoutName = updatedWorkout.WorkoutName,
                Exercise = updatedWorkout.Exercise,
                Description = updatedWorkout.Description,
                Note = updatedWorkout.Note,
                StudentId = updatedWorkout.StudentId,
            };

            return updatedWorkoutDTO;
                

        }

        public WorkoutFindByIdResponse FindById(long id)
        {
            var workout = _repository.FindByID(id);

            // Verifica se o treino foi encontrado
            if (workout == null)
            {
                throw new KeyNotFoundException($"Treino com o ID {id} não foi encontrado.");
            }

            // Mapeia a entidade para o DTO
            var responseDTO = new WorkoutFindByIdResponse
            {
                WorkoutName = workout.WorkoutName,
                Exercise = workout.Exercise,
                Description = workout.Description,
                CreatedAt = workout.CreatedAt.ToString("dd/MM/yyyy"),
                Note = workout.Note,
                StudentId = workout.StudentId,
            };

            return responseDTO;
        }

        public void Delete(long id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidOperationException("A entidade com o ID fornecido não foi encontrada.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Falha ao tentar deletar a entidade.", ex);
            }
        }
    }
}
