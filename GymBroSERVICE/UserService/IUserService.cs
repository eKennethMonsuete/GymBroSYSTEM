
using GymBroSERVICE.UserService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService
{
    public interface IUserService
    {

        UserResponseDTO Create(UserInputDTO user);

       // UserResponseDTO FindByID(long id);

       // List<UserResponseDTO> FindAll();

        UserResponseDTO Update(UserInputUpdateDTO user, long id);

        void Delete(long id);
    }
}
