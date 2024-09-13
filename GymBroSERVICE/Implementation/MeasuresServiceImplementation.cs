
using GymBroAPPLICATION.DTOs;
using GymBroDOMAIN.Entity;
using GymBroINFRA.Repository;
using GymBroSERVICE.Service;

namespace GymBroSERVICE.Implementation
{
    public class MeasuresServiceImplementation : IMeasuresService
    {

        private readonly IRepository<Measures> _repository;

        public MeasuresServiceImplementation(IRepository<Measures> repository)
        {
            _repository = repository;
        }

        public MeasuresDTO Create(MeasuresDTO measures)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<MeasuresDTO> FindAll()
        {
            var measures = _repository.FindAll();

            // Converte a lista de Measures para MeasuresDTO
            var measuresDTOs = measures.Select(measure => new MeasuresDTO
            {
                Id = measure.Id,
                Weight = measure.Weight,
                RightBiceps = measure.RightBiceps,
                LeftBiceps = measure.LeftBiceps,
                Hips = measure.Hips,
                // Adicione os outros campos conforme necessário
            }).ToList();

            return measuresDTOs;
        }

        public MeasuresDTO FindByID(long id)
        {
            throw new NotImplementedException();
        }

        public MeasuresDTO Update(MeasuresDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
