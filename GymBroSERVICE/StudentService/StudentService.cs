using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.PersonalService.DTO;
using GymBroSERVICE.StudentService.DTO;


namespace GymBroSERVICE.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public List<StudentFindAllResponseDTO> FindAll()
        {
            var students = _repository.FindAll();
            return students.Select(student => new StudentFindAllResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone
            }).ToList();                               
        }

        public StudentFindByIdResponseDTO FindById(long id)
        {
            var student = _repository.FindByID(id);
            if (student == null) throw new Exception("Student not found.");
            return new StudentFindByIdResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,

                Personal = student.Personal != null ? new PersonalResponseToStudentDTO
                {
                    Name = student.Personal.Name,
                    Email = student.Personal.Email,
                    Phone = student.Personal.Phone
                    
                   
                } : null,

                Measures = student.Measures?.Select(measure => new MeasuresResponseDTO
                {                 
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

        public StudentFindAllResponseDTO Create(StudentCreateDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(studentDto.Password, 13),
                Phone = studentDto.Phone,
                PersonalId = studentDto.PersonalId,

                // Adicione lógica para workout caso exista
            };

            var createdStudent = _repository.Create(student);
            return new StudentFindAllResponseDTO
            {
                Id = createdStudent.Id,
                Name = createdStudent.Name,
                LastName = createdStudent.LastName,
                Email = createdStudent.Email,
                Phone = createdStudent.Phone,
            };
        }

        public StudentFindByIdResponseDTO Update(long id, StudentCreateDTO studentDto)
        {
            var existingStudent = _repository.FindByID(id);
            if (existingStudent == null) throw new KeyNotFoundException("Student not found.");

            existingStudent.Name = studentDto.Name;
            existingStudent.LastName = studentDto.LastName;
            existingStudent.Email = studentDto.Email;
            existingStudent.Phone = studentDto.Phone;
            existingStudent.PersonalId = studentDto.PersonalId;
            if (!string.IsNullOrEmpty(studentDto.Password))
            {
               if (!BCrypt.Net.BCrypt.EnhancedVerify(studentDto.Password, existingStudent.Password))
               {
                    
                    existingStudent.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(studentDto.Password, 13);
               }
            }
            else
            {
                throw new ArgumentException("A senha não pode ser nula ou vazia.");
            }
           
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
