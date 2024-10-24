using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.WorkoutService.DTO.Request;
using GymBroSERVICE.WorkoutService.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.WorkoutService
{
    public interface IWorkoutService
    {

        Task<List<WorkoutFindAllResponse>> FindAll();

        WorkoutFindByIdResponse FindById(long id);

        Task<WorkoutFindAllResponse> Create(WorkoutCreateRequest workout);

        WorkoutFindAllResponse Update(WorkoutUpdateRequest workoutUpdate, long id);

        void Delete(long id);

        

    }
}
