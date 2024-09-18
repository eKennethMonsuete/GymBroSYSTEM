using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.StudentService.DTO;
using GymBroSERVICE.TeacherService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherService(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        // Retorna todos os professores
        public List<TeacherResponseDTO> FindAll()
        {
            var teachers = _repository.FindAll();
            return teachers.Select(teacher => new TeacherResponseDTO
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Password = teacher.Password,
                LastName = teacher.LastName,
                // Supondo que você queira mostrar os alunos do professor
                Students = teacher.Students?.Select(student => new StudentResponseDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    LastName = student.LastName
                }).ToList()
            }).ToList();
        }

        // Retorna um professor pelo ID
        public TeacherResponseDTO FindById(long id)
        {
            var teacher = _repository.FindByID(id);

            if (teacher == null)
                throw new KeyNotFoundException("Professor não encontrado.");

            return new TeacherResponseDTO
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Password = teacher.Password,
                LastName = teacher.LastName,
                Students = teacher.Students?.Select(student => new StudentResponseDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    LastName = student.LastName
                }).ToList()
            };
        }

        // Cria um novo professor
        public TeacherResponseDTO Create(TeacherCreateDTO teacherDto)
        {
            var teacher = new Teacher
            {
                Name = teacherDto.Name,
                Email = teacherDto.Email,
                Password = teacherDto.Password,
                LastName = teacherDto.LastName
            };

            var createdTeacher = _repository.Create(teacher);

            return new TeacherResponseDTO
            {
                Id = createdTeacher.Id,
                Name = createdTeacher.Name,
                Email = createdTeacher.Email,
                Password = createdTeacher.Password,
                LastName = createdTeacher.LastName
            };
        }

        // Atualiza um professor existente
        public TeacherResponseDTO Update(long id, TeacherCreateDTO teacherDto)
        {
            var existingTeacher = _repository.FindByID(id);

            if (existingTeacher == null)
                throw new KeyNotFoundException("Professor não encontrado.");

            existingTeacher.Name = teacherDto.Name;
            existingTeacher.Email = teacherDto.Email;
            existingTeacher.Password = teacherDto.Password;
            existingTeacher.LastName = teacherDto.LastName;

            var updatedTeacher = _repository.Update(existingTeacher);

            return new TeacherResponseDTO
            {
                Id = updatedTeacher.Id,
                Name = updatedTeacher.Name,
                Email = updatedTeacher.Email,
                Password = updatedTeacher.Password,
                LastName = updatedTeacher.LastName
            };
        }

        // Exclui um professor
        public void Delete(long id)
        {
            var teacher = _repository.FindByID(id);
            if (teacher == null)
                throw new KeyNotFoundException("Professor não encontrado.");

            _repository.Delete(id);
        }
    }
}
