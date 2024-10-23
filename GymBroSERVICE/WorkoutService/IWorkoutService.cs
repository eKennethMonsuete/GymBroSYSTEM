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

    }
}
