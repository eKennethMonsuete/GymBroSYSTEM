using GymBroSERVICE.MeasuresService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.MeasuresService
{
    public interface IMeasuresService
    {
        Task<MeasuresResponseDTO> Create(MeasuresCreateInputDTO measures);

        MeasuresResponseDTO FindByID(long id);

        Task<List<MeasuresResponseDTO>> FindAll();

        MeasuresResponseDTO Update(MeasuresUpdateInputDTO measures, long id);

        void Delete(long id);

       

    }
}
