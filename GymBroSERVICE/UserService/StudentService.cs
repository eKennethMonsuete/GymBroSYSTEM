using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.UserService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.UserService
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public List<StudentResponseDTO> FindAll()
        {
            var students = _repository.FindAll();
            return students.Select(student => new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Teacher = student.Teacher != null ? new TeacherResponseDTO
                {
                    Id = student.Teacher.Id,
                    Name = student.Teacher.Name,
                    Email = student.Teacher.Email,
                    LastName = student.Teacher.LastName,
                    // Adicione outros campos de TeacherResponseDTO conforme necessário
                } : null,

                Measures = student.Measures?.Select(measure => new MeasuresResponseDTO
                {
                    Id = measure.Id,
                    Weight = measure.Weight,
                    Hips = measure.Hips,
                    LeftBiceps = measure.LeftBiceps,
                    RightBiceps = measure.RightBiceps,
                    LeftQuadriceps = measure.LeftQuadriceps,
                    RightQuadriceps = measure.RightQuadriceps,
                    LeftCalf = measure.LeftCalf,
                    RightCalf = measure.RightCalf
                }).ToList(),

            }).ToList();
        }

        public StudentResponseDTO FindById(long id)
        {
            var student = _repository.FindByID(id);
            if (student == null) throw new KeyNotFoundException("Student not found.");

            return new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Teacher = student.Teacher != null ? new TeacherResponseDTO
                {
                    Id = student.Teacher.Id,
                    
                    // Adicione outros campos de TeacherResponseDTO conforme necessário
                } : null,


                Measures = student.Measures?.Select(measure => new MeasuresResponseDTO
                {
                    Id = measure.Id,
                    Weight = measure.Weight,
                    Hips = measure.Hips,
                    LeftBiceps = measure.LeftBiceps,
                    RightBiceps = measure.RightBiceps,
                    LeftQuadriceps = measure.LeftQuadriceps,
                    RightQuadriceps = measure.RightQuadriceps,
                    LeftCalf = measure.LeftCalf,
                    RightCalf = measure.RightCalf
                }).ToList()                                               
            };
        }

        public StudentResponseDTO Create(StudentCreateDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Password = studentDto.Password,
                TeacherId = studentDto.TeacherId,
                
                // Adicione lógica para workout caso exista
            };

            var createdStudent = _repository.Create(student);
            return FindById(createdStudent.Id);
        }

        public StudentResponseDTO Update(long id, StudentCreateDTO studentDto)
        {
            var existingStudent = _repository.FindByID(id);
            if (existingStudent == null) throw new KeyNotFoundException("Student not found.");

            existingStudent.Name = studentDto.Name;
            existingStudent.LastName = studentDto.LastName;
            existingStudent.Email = studentDto.Email;
            existingStudent.TeacherId = studentDto.TeacherId;
            // Atualize medidas e treinos se necessário

            _repository.Update(existingStudent);
            return FindById(id);
        }

        public void Delete(long id)
        {
            var student = _repository.FindByID(id);
            if (student == null) throw new KeyNotFoundException("Student not found.");

            _repository.Delete(id);
        }
    }
}
