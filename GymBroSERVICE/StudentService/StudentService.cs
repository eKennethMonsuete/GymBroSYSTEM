using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;
using GymBroSERVICE.PersonalService.DTO;
using GymBroSERVICE.StudentlService.DTO;
using GymBroSERVICE.StudentService.DTO;
using Microsoft.EntityFrameworkCore;


namespace GymBroSERVICE.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IRepository<User> _UserRepository;

        public StudentService(IRepository<Student> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _UserRepository = userRepository;
        }

        public async Task<List<StudentFindAllResponseDTO>> FindAll()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(student => new StudentFindAllResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.User.Email,
                Phone = student.Phone,
                CreatedAt = student.CreatedAt.ToString("dd/MM/yyyy")
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
                Email = student.User.Email,
                Phone = student.Phone,
                PesonalId = student.PersonalId.HasValue ? student.PersonalId.Value : (long?)null,
                CreatedAt = student.CreatedAt.ToString("dd/MM/yyyy"),
                
               
              
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

        public async Task<StudentFindAllResponseDTO> Create(StudentCreateDTO studentDto)
        {
           var exists = await _UserRepository.FindAllAsync(e => e.Email.ToLower() == studentDto.Email.ToLower());

            if (exists.Any()) throw new Exception("Usário já cadastrado");
            

            var user = new User
            {
                Email = studentDto.Email.ToLower(),
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(studentDto.Password, 13),
            };

            var userResult = await _UserRepository.CreateAsync(user);

            if (userResult.Id == 0)
            {
                throw new Exception("Falha ao criar o usuário id tá 0.");
            }

            var student = new Student
            {
                Name = studentDto.Name,
                LastName = studentDto.LastName,
                Phone = studentDto.Phone,
                PersonalId = studentDto.PersonalId,
                UserId = userResult.Id,
               
            };

            var createdStudent = await _repository.CreateAsync(student);

            user.StudentId = student.Id;

            var userToUpdate =  _UserRepository.FindByID(userResult.Id);

            if (userToUpdate == null)
            {
                throw new Exception("Usuário não encontrado para atualizar o StudentId.");
            }
            _UserRepository.Update(userToUpdate);


            return new StudentFindAllResponseDTO
            {
                Id = createdStudent.Id,
                Name = createdStudent.Name,
                LastName = createdStudent.LastName,
                Email = userResult.Email,
                Phone = createdStudent.Phone,
                CreatedAt = student.CreatedAt.ToString("dd/MM/yyyy")
            };
        }

        public StudentFindByIdResponseDTO Update(long id, StudentUpdateDTO studentDto)
        {

            var student = _repository.Where(e => e.Id == id).Include(e => e.User).FirstOrDefault();

            if (student == null)
            {
                throw new KeyNotFoundException("Student não encontrado.");
            }


            student.Name = studentDto.Name;
            student.LastName = studentDto.LastName;
            student.Phone = studentDto.Phone;
            student.PersonalId = studentDto.PersonalId;
            student.User.Email = studentDto.Email;
           
          var result =  _repository.Update(student);
          var userResult = _UserRepository.Update(student.User);

            return new StudentFindByIdResponseDTO
            {
                Id = result.Id,
                Name = result.Name,
                LastName = result.LastName,
                Phone = result.Phone,
                Email = student.User.Email
            };
        }

        public void Delete(long id)
        {
            var student = _repository.FindByID(id);
            if (student == null) throw new KeyNotFoundException("Student not found.");

            student.User.StudentId = null;
            _UserRepository.Update(student.User);
                

            _repository.Delete(id);
            _UserRepository.Delete(student.UserId);
        }
    }
}
