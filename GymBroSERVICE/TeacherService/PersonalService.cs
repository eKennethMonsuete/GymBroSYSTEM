using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.StudentService.DTO;
using GymBroSERVICE.TeacherService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.TeacherService
{
    public class PersonalService : IPersonalService
    {
        private readonly IRepository<Personal> _repository;

        public PersonalService(IRepository<Personal> repository)
        {
            _repository = repository;
        }

        //DTOentrada - DTOSaida - Interface - SErvice

        
        public List<PersonalListAllResponseDTO> FindAll()
        {
            var personal = _repository.FindAll();
            return personal.Select(teacher => new PersonalListAllResponseDTO
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                LastName = teacher.LastName,
                Phone = teacher.Phone,                        
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
                Email = personal.Email,
                LastName = personal.LastName,
                Phone = personal.Phone,
                Students = personal.Students?.Select(student => new StudentFindAllResponseDTO
                {   Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    LastName = student.LastName,
                    Phone = student.Phone,
                }).ToList() 
            };
            
        }

        
        public PersonalListAllResponseDTO Create(PersonalCreateDTO personalDto)
        {
            var personal = new Personal
            {
                Name = personalDto.Name,
                Email = personalDto.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(personalDto.Password, 13),
                LastName = personalDto.LastName,
                Phone = personalDto.Phone,
            };

            var createdPersonal = _repository.Create(personal);

            return new PersonalListAllResponseDTO
            {
                Id = createdPersonal.Id,
                Name = createdPersonal.Name,
                Email = createdPersonal.Email,
                
                LastName = createdPersonal.LastName,
                Phone = createdPersonal.Phone,
            };
        }

        
        public PersonalListAllResponseDTO Update(long id, PersonalCreateDTO personalDto)
        {
            var existingPersonal = _repository.FindByID(id);

            if (existingPersonal == null)  
                throw new KeyNotFoundException("Personal não encontrado.");

            existingPersonal.Name = personalDto.Name;
            existingPersonal.Email = personalDto.Email;
            existingPersonal.Phone = personalDto.Phone;
            existingPersonal.LastName = personalDto.LastName;

            if (!string.IsNullOrEmpty(personalDto.Password))
            {
                if (!BCrypt.Net.BCrypt.EnhancedVerify(personalDto.Password, existingPersonal.Password))
                {
                    existingPersonal.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(personalDto.Password, 13);
                }
            }
            else
            {
             
                throw new ArgumentException("A senha não pode ser nula ou vazia.");
            }

           
                                

            var updatedPersonal = _repository.Update(existingPersonal);

            return new PersonalListAllResponseDTO
            {
                Id = existingPersonal.Id,
                Name = updatedPersonal.Name,
                Email = updatedPersonal.Email,
                LastName = updatedPersonal.LastName,
                Phone = updatedPersonal.Phone
                
            };
        }

        
        public void Delete(long id)
        {
            var personal = _repository.FindByID(id);
            if (personal == null)
                throw new KeyNotFoundException("Professor não encontrado.");

            _repository.Delete(id);
        }
    }
}
