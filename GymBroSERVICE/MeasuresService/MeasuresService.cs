
using GymBroINFRA.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.MeasuresService.DTO;

namespace GymBroSERVICE.MeasuresService
{
    public class MeasuresService : IMeasuresService
    {
        private readonly IRepository<Measures> _repository;

        public MeasuresService(IRepository<Measures> repository)
        {
            _repository = repository;
        }
        public List<MeasuresResponseDTO> FindAll()
        {
            // Chama o repositório genérico para obter todas as entidades de Measures
            var measuresEntities = _repository.FindAll();

            // Mapeia as entidades Measures para MeasuresResponseDTO
            var measuresDTOs = measuresEntities.Select(measure => new MeasuresResponseDTO
            {
                Id = measure.Id,
                Weight = measure.Weight,
                Hips = measure.Hips,
                LeftBiceps = measure.LeftBiceps,
                RightBiceps = measure.RightBiceps,
                LeftQuadriceps = measure.LeftQuadriceps,
                RightQuadriceps = measure.RightQuadriceps,
                LeftCalf = measure.LeftCalf,
                RightCalf = measure.RightCalf,
               // StudentId = measure.StudentId,
            }).ToList();

            return measuresDTOs;
        }

        public MeasuresResponseDTO FindByID(long id)
        {
            // Busca a medida no repositório pelo ID
            var measure = _repository.FindByID(id);

            // Verifica se a medida foi encontrada
            if (measure == null)
            {
                throw new KeyNotFoundException($"Medida com o ID {id} não foi encontrada.");
            }

            // Retorna o DTO preenchido com os dados da medida encontrada
            var responseDTO = new MeasuresResponseDTO
            {
                Id = measure.Id,
                Weight = measure.Weight,
                Hips = measure.Hips,
                LeftBiceps = measure.LeftBiceps,
                RightBiceps = measure.RightBiceps,
                LeftQuadriceps = measure.LeftQuadriceps,
                RightQuadriceps = measure.RightQuadriceps,
                LeftCalf = measure.LeftCalf,
                RightCalf = measure.RightCalf,
               // StudentId = measure.StudentId
            };

            return responseDTO;
        }
        public MeasuresResponseDTO Create(MeasuresCreateInputDTO measures)
        {

            if (measures == null)
            {
                throw new ArgumentNullException( "As medidas não podem ser nulas.");
            }

            //TODO: Validações
            var measure = new Measures
            {
                Weight = measures.Weight,
                Hips = measures.Hips,
                LeftBiceps = measures.LeftBiceps,
                RightBiceps = measures.RightBiceps,
                LeftQuadriceps = measures.LeftQuadriceps,
                RightQuadriceps = measures.RightQuadriceps,
                LeftCalf = measures.LeftCalf,
                RightCalf = measures.RightCalf,
               // StudentId = measures.StudentId

            };

            if (measure.Weight < 0 ||
                measure.Hips < 0 ||
                measure.LeftBiceps < 0 ||
                measure.RightBiceps < 0 ||
                measure.LeftQuadriceps < 0 ||
                measure.RightQuadriceps < 0 ||
                measure.LeftCalf < 0 ||
                measure.RightCalf < 0 )
            {
                throw new ArgumentException("As medidas não podem ser menores que zero.");
            }

            var result = _repository.Create(measure);
            
            

            return new MeasuresResponseDTO
            {
                Id = result.Id,
                Hips = measure.Hips,
                LeftBiceps = measure.LeftBiceps,
                RightBiceps = measure.RightBiceps,
                Weight = measure.Weight
            };

            
        }



        public MeasuresResponseDTO Update(MeasuresUpdateInputDTO measuresInputUpdateDTO, long id)
        {
            if (measuresInputUpdateDTO == null)
            {
                throw new ArgumentNullException(nameof(measuresInputUpdateDTO), "As medidas não podem ser nulas.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.", nameof(id));
            }

            // Busca a entidade existente
            var existingMeasures = _repository.FindByID(id);

            if (existingMeasures == null)
            {
                throw new KeyNotFoundException("Entidade com o ID fornecido não foi encontrada.");
            }

            // Atualiza as propriedades da entidade existente com os valores do DTO
            existingMeasures.Weight = measuresInputUpdateDTO.Weight;
            existingMeasures.Hips = measuresInputUpdateDTO.Hips;
            existingMeasures.LeftBiceps = measuresInputUpdateDTO.LeftBiceps;
            existingMeasures.RightBiceps = measuresInputUpdateDTO.RightBiceps;
            existingMeasures.LeftQuadriceps = measuresInputUpdateDTO.LeftQuadriceps;
            existingMeasures.RightQuadriceps = measuresInputUpdateDTO.RightQuadriceps;
            existingMeasures.LeftCalf = measuresInputUpdateDTO.LeftCalf;
            existingMeasures.RightCalf = measuresInputUpdateDTO.RightCalf;
            //existingMeasures.StudentId = measuresInputUpdateDTO.StudentId;

            // Atualiza a entidade no repositório
            var updatedMeasures = _repository.Update(existingMeasures);

            if (updatedMeasures == null)
            {
                throw new InvalidOperationException("Falha ao atualizar a entidade.");
            }

            // Converte a entidade atualizada de volta para DTO
            var updatedMeasuresDTO = new MeasuresResponseDTO
            {
        
                Id = existingMeasures.Id,
                Weight = updatedMeasures.Weight,
                Hips = updatedMeasures.Hips,
                LeftBiceps = updatedMeasures.LeftBiceps,
                RightBiceps = updatedMeasures.RightBiceps,
                LeftQuadriceps = updatedMeasures.LeftQuadriceps,
                RightQuadriceps = updatedMeasures.RightQuadriceps,
                LeftCalf = updatedMeasures.LeftCalf,
                RightCalf = updatedMeasures.RightCalf,
               // StudentId = updatedMeasures.StudentId
            };

            return updatedMeasuresDTO;
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

