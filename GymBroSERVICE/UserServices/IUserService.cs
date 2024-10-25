using GymBroSERVICE.UserServices.DTO;

namespace GymBroSERVICE.UserServices
{
    public interface IUserService
    {

        Task<LoginResultDTO> Login(LoginDTO authDTO);
    }
}
