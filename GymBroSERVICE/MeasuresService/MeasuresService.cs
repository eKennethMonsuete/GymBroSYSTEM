﻿
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
            
            var measuresEntities = _repository.FindAll();

            
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
                StudentId = measure.StudentId,
            }).ToList();

            return measuresDTOs;
        }

        public MeasuresResponseDTO FindByID(long id)
        {
            var measure = _repository.FindByID(id);
                        
            if (measure == null)
            {
                throw new KeyNotFoundException($"Medida com o ID {id} não foi encontrada.");
            }
                        
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
                StudentId = measure.StudentId
            };

            return responseDTO;
        }
        public MeasuresResponseDTO Create(MeasuresCreateInputDTO measures)
        {

            if (measures == null)
            {
                throw new ArgumentNullException( "As medidas não podem ser nulas.");
            }

            
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
                StudentId = measures.StudentId

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
            if(measures.StudentId != null)
                {
                var result = _repository.Create(measure);
                } else
            {
                throw new ArgumentException("É preciso passar o id de um aluno.");
            }
                                
            return new MeasuresResponseDTO
            {   Id = measure.Id,
                Hips = measure.Hips,
                LeftBiceps = measure.LeftBiceps,
                RightBiceps = measure.RightBiceps,
                Weight = measure.Weight,
                LeftQuadriceps = measures.LeftQuadriceps,
                RightQuadriceps = measures.RightQuadriceps,
                LeftCalf = measures.LeftCalf,
                RightCalf = measures.RightCalf,
                StudentId = measure.StudentId


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
                        
            var existingMeasures = _repository.FindByID(id);

            if (existingMeasures == null)
            {
                throw new KeyNotFoundException("Entidade com o ID fornecido não foi encontrada.");
            }
            if (measuresInputUpdateDTO.Weight < 0 ||
               measuresInputUpdateDTO.Hips < 0 ||
               measuresInputUpdateDTO.LeftBiceps < 0 ||
               measuresInputUpdateDTO.RightBiceps < 0 ||
               measuresInputUpdateDTO.LeftQuadriceps < 0 ||
               measuresInputUpdateDTO.RightQuadriceps < 0 ||
               measuresInputUpdateDTO.LeftCalf < 0 ||
               measuresInputUpdateDTO.RightCalf < 0)
            {
                throw new ArgumentException("As medidas não podem ser menores que zero.");
            }
                                    
            existingMeasures.Weight = measuresInputUpdateDTO.Weight;
            existingMeasures.Hips = measuresInputUpdateDTO.Hips;
            existingMeasures.LeftBiceps = measuresInputUpdateDTO.LeftBiceps;
            existingMeasures.RightBiceps = measuresInputUpdateDTO.RightBiceps;
            existingMeasures.LeftQuadriceps = measuresInputUpdateDTO.LeftQuadriceps;
            existingMeasures.RightQuadriceps = measuresInputUpdateDTO.RightQuadriceps;
            existingMeasures.LeftCalf = measuresInputUpdateDTO.LeftCalf;
            existingMeasures.RightCalf = measuresInputUpdateDTO.RightCalf;
            existingMeasures.StudentId = measuresInputUpdateDTO.StudentId;

            
            var updatedMeasures = _repository.Update(existingMeasures);

            if (updatedMeasures == null)
            {
                throw new InvalidOperationException("Falha ao atualizar a entidade.");
            }

            
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
                StudentId = updatedMeasures.StudentId
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

