using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.UserServices.DTO;

namespace GymBroSERVICE.UserServices
{
    public class UserServices : IUserService
    {

        private readonly IRepository<User> _repository;

        public UserServices(IRepository<User> repository)
        {
            _repository = repository;
        }

        public LoginResultDTO Login(LoginDTO authDTO)
        {
            var user = _repository.FindByEmail(authDTO.Email.ToLower());

            if (user == null)
                throw new Exception("Credenciais inválidas");
                

            bool match = BCrypt.Net.BCrypt.EnhancedVerify(authDTO.Password, user.Password);

            if (!match)
                throw new Exception("Credenciais inválidas");

            //GERAR O TOKEN



            return new LoginResultDTO
            {
                AccessToken = "",
                ExpiratedAt = DateTime.Now,
            };
        }
    }
}
