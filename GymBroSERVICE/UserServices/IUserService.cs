using GymBroSERVICE.UserServices.DTO;

namespace GymBroSERVICE.UserServices
{
    public interface IUserService
    {

        LoginResultDTO Login(LoginDTO authDTO);
    }
}
