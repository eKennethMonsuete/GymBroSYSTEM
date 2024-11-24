using GymBroINFRA.Entity;
using GymBroINFRA.Models;
using GymBroINFRA.Repository;
using GymBroSERVICE.UserServices.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymBroSERVICE.UserServices
{
    public class UserServices : IUserService
    {

        private readonly IRepository<User> _repository;
        private readonly IRepository<Personal> _repositoryPersonal;
        private readonly IRepository<Student> _repositoryStudent;
        private readonly TokenConfiguration _configuration;

        public UserServices(IRepository<User> repository, IRepository<Student> repositoryStudent, IRepository<Personal> repositoryPersonal, TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _repositoryPersonal = repositoryPersonal;
            _repositoryStudent = repositoryStudent;
            _configuration = tokenConfiguration;
        }

        public async  Task<LoginResultDTO> Login(LoginDTO authDTO)
        {
            var user = await _repository.FindByEmail(authDTO.Email.ToLower()) ?? throw new Exception("Credenciais inválidas");

            bool match = BCrypt.Net.BCrypt.EnhancedVerify(authDTO.Password, user.Password);

            if (!match)
                throw new Exception("Credenciais inválidas");

            //GERAR O TOKEN
            string token = GenerateToken(user);

            var studentId = _repositoryStudent.FindByID;


            return new LoginResultDTO
            {
                AccessToken = token,
                ExpiratedAt = DateTime.Now.AddMinutes(_configuration.Minutes)
                
                
            };
        }


        private string GenerateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (user.StudentId != null)
            {

                claims.Add(new Claim(ClaimTypes.Sid, user.StudentId.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "STUDENT"));
                claims.Add(new Claim(ClaimTypes.Name, user.Student.Name.ToString()));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Sid, user.PersonalId.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "PERSONAL"));
                claims.Add(new Claim(ClaimTypes.Name, user.Personal.Name.ToString()));
            }

            return GetToken(claims);
        }

        private string GetToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var options = new JwtSecurityToken(issuer: _configuration.Issuer,
                    audience: _configuration.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_configuration.Minutes),
                    signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(options);
        }
    }
}
