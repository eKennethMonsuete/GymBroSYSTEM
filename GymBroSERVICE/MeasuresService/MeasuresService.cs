
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

        public MeasuresResponseDTO Create(MeasuresCreateInputDTO measures)
        {
            //TODO: Validações
            var measure = new Measures
            {
                Hips = measures.Hips,
                LeftBiceps = measures.LeftBiceps,
                RightBiceps = measures.RightBiceps,
                Weight = measures.Weight
            };

            var result = _repository.Create(measure);
            
            

            return new MeasuresResponseDTO
            {
                Id = result.Id,
                Hips = measure.Hips,
                LeftBiceps = measure.LeftBiceps,
                RightBiceps = measure.RightBiceps,
                Weight = measure.Weight
            };

            throw new NotImplementedException();
        }




        //public MeasuresResponseDTO Create(MeasuresCreateInputDTO measures)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<MeasuresResponseDTO> FindAll()
        //{
        //    var measures = _repository.FindAll();

        //    // Converte a lista de Measures para MeasuresDTO
        //    var measuresDTOs = measures.Select(measure => new MeasuresResponseDTO
        //    {
        //        Id = measure.Id,
        //        Weight = measure.Weight,
        //        RightBiceps = measure.RightBiceps,
        //        LeftBiceps = measure.LeftBiceps,
        //        Hips = measure.Hips,
        //        // Adicione os outros campos conforme necessário
        //    }).ToList();

        //    return measuresDTOs;
        //}

        //public MeasuresResponseDTO FindByID(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public MeasuresResponseDTO Update(MeasuresResponseDTO book)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

