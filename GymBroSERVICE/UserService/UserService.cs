using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.UserService.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        //public List<UserResponseDTO> FindAll()
        //{
        //    var UsersAtribbutes = _repository.FindAll();

            
        //    var userDTOs = UsersAtribbutes.Select(user => new UserResponseDTO
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        LastName = user.LastName,
        //        Password = user.Password,
        //        ResultsMeasures = user.Measures?.Select(measures => new MeasuresResponseDTO
        //        {
        //            Id = measures.Id,
        //            Weight = measures.Weight,
        //            Hips = measures.Hips,
        //            LeftBiceps = measures.LeftBiceps,
        //            RightBiceps = measures.RightBiceps,
        //            LeftQuadriceps = measures.LeftQuadriceps,
        //            RightQuadriceps = measures.RightQuadriceps,
        //            LeftCalf = measures.LeftCalf,
        //            RightCalf = measures.RightCalf

        //        }).ToList()
        //    }).ToList();

        //    return userDTOs;
        //}

       

        //public UserResponseDTO FindByID(long id)
        //{
        //    var user = _repository.FindByID(id);
        //    if (user == null)
        //    {
        //        throw new KeyNotFoundException($"Usuário com o ID {id} não foi encontrada.");
        //    }
        //    var responseUserDTO = new UserResponseDTO()
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        LastName = user.LastName,
        //        Password = user.Password,
        //        ResultsMeasures = user.Measures?.Select(measures => new MeasuresResponseDTO
        //        {
        //            Id = measures.Id,
        //            Weight = measures.Weight,
        //            Hips = measures.Hips,
        //            LeftBiceps = measures.LeftBiceps,
        //            RightBiceps = measures.RightBiceps,
        //            LeftQuadriceps = measures.LeftQuadriceps,
        //            RightQuadriceps = measures.RightQuadriceps,
        //            LeftCalf = measures.LeftCalf,
        //            RightCalf = measures.RightCalf,
        //        }).ToList()
        //    };
        //    return responseUserDTO;
        //}

        public UserResponseDTO Create(UserInputDTO userInput)
        {
            if (userInput == null)
            {
                throw new ArgumentNullException("Os atributos do user não podem ser nulos.");
            }
            var user = new User()
            {
                
                Email = userInput.Email,
                Password = userInput.Password,
            };
            var result = _repository.Create(user);

            return new UserResponseDTO
            {
                Id = result.Id,
                Name = userInput.Name,
                Email = userInput.Email,
                LastName = userInput.LastName,
                Password = userInput.Password
            };              
        }

        

       

        public UserResponseDTO Update(UserInputUpdateDTO userInputUpdateDTO, long id)
        {
            if (userInputUpdateDTO == null)
            {
                throw new ArgumentNullException(nameof(userInputUpdateDTO), "Os dados do usuário não podem ser nulos.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.", nameof(id));
            }

            // Busca o usuário existente no repositório
            var existingUser = _repository.FindByID(id);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("Usuário com o ID fornecido não foi encontrado.");
            }

            // Atualiza as propriedades do usuário existente com os valores do DTO
            
            existingUser.Email = userInputUpdateDTO.Email;
            
            existingUser.Password = userInputUpdateDTO.Password;

            // Atualiza o usuário no repositório
            var updatedUser = _repository.Update(existingUser);

            if (updatedUser == null)
            {
                throw new InvalidOperationException("Falha ao atualizar o usuário.");
            }

            // Converte a entidade atualizada de volta para DTO
            var updatedUserDTO = new UserResponseDTO
            {
                Id = existingUser.Id,
                
                Email = updatedUser.Email,
                
                Password = updatedUser.Password
            };

            return updatedUserDTO;

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
