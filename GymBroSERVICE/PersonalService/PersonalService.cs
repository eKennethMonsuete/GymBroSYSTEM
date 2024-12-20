﻿using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.PersonalService.DTO;
using GymBroSERVICE.StudentService.DTO;
using Microsoft.EntityFrameworkCore;

namespace GymBroSERVICE.PersonalService
{
    public class PersonalService : IPersonalService
    {
        private readonly IRepository<Personal> _repository;
        private readonly IRepository<User> _UserRepository;

        public PersonalService(IRepository<Personal> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _UserRepository = userRepository;
        }

        //DTOentrada - DTOSaida - Interface - SErvice

        public async Task<List<PersonalListAllResponseDTO>> FindAll()
        {
            var personal = await _repository.GetAllAsync();
            return personal.Select(teacher => new PersonalListAllResponseDTO
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.User.Email,
                LastName = teacher.LastName,
                Phone = teacher.Phone,
                CreatedAt = teacher.CreatedAt.ToString("dd/MM/yyyy")
            }).ToList();
        }

        public PersonalFindByIdResponse FindById(long id)
        {
            var personal = _repository.FindByID(id);

            if (personal == null)
                throw new Exception("Professor não encontrado.");

            return new PersonalFindByIdResponse
            {
                Id = personal.Id,
                Name = personal.Name,
                Email = personal.User.Email,
                LastName = personal.LastName,
                Phone = personal.Phone,
                CreatedAt = personal.CreatedAt.ToString("dd/MM/yyyy"),
                Students = personal.Students?.Select(student => new StudentResponseToPersonalFindById
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.User.Email,
                    LastName = student.LastName,
                    Phone = student.Phone,
                    CreatedAt = student.CreatedAt.ToString("dd/MM/yyyy")
                }).ToList()
            };

        }

        public  async Task<PersonalListAllResponseDTO> Create(PersonalCreateDTO personalDto)
        {
            var exists = 
                await _UserRepository.FindAllAsync
                (e => e.Email.ToLower() == personalDto.Email.ToLower());

            if (exists.Any()) throw new Exception("Usário já cadastrado");

            var user = new User
            {
                Email = personalDto.Email.ToLower(),
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(personalDto.Password, 13),
            };

            var userResult = await _UserRepository.CreateAsync(user);

            var personal = new Personal
            {
                Name = personalDto.Name,
                LastName = personalDto.LastName,
                Phone = personalDto.Phone,
                UserId = userResult.Id,
            };

            var createdPersonal = await _repository.CreateAsync(personal);

            user.PersonalId = personal.Id;
            _UserRepository.Update(user);

           return new PersonalListAllResponseDTO
            {
                Id = createdPersonal.Id,
                Name = createdPersonal.Name,
                Email = userResult.Email,
                LastName = createdPersonal.LastName,
                Phone = createdPersonal.Phone,
                CreatedAt = createdPersonal.CreatedAt.ToString("dd/MM/yyyy")
            };
        }

        public PersonalListAllResponseDTO Update(long id, PersonalUpdateDTO personalDto)
        {
            

            var personal = _repository.Where(e => e.Id == id).Include(e => e.User).FirstOrDefault();

            if (personal == null)
                throw new KeyNotFoundException("Personal não encontrado.");

            personal.Name = personalDto.Name;
            personal.Phone = personalDto.Phone;
            personal.LastName = personalDto.LastName;
            personal.User.Email = personalDto.Email;

            var result = _repository.Update(personal);
            var userResult = _UserRepository.Update(personal.User);

            return new PersonalListAllResponseDTO
            {
                Id = result.Id,
                Name = result.Name,
                Email = personal.User.Email,
                LastName = result.LastName,
                Phone = result.Phone,
                CreatedAt = personal.CreatedAt.ToString("dd/MM/yyyy")


            };
        }

        public void Delete(long id)
        {
            

            var personal = _repository.FindByID(id);
            if (personal == null)
                throw new KeyNotFoundException("Professor não encontrado.");

            personal.User.PersonalId = null;
            _UserRepository.Update(personal.User);

            _repository.Delete(id);
            _UserRepository.Delete(personal.UserId);
            }
            
        
    }
}
