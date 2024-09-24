using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.AuthService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.AuthService
{
    public class AuthService : IAuth
    {

        private readonly IRepository<User> _repository;

        public AuthService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public string Login(AuthDTO authDTO)
        {
            var user = _repository.FindByEmail(authDTO.Email);

            if (user == null)
            {
                return "Credenciais incorretas.";
            }

            bool match = BCrypt.Net.BCrypt.EnhancedVerify(authDTO.Password, user.Password);

            if (match == true)
            {
                return "Credenciais corretas.";
            }
            else
            {
                return "Credenciais incorretas.";
            }

        }
    }
}
