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
        MeasuresResponseDTO Create(MeasuresCreateInputDTO measures);
        
        //MeasuresResponseDTO FindByID(long id);

        //List<MeasuresResponseDTO> FindAll();

        //MeasuresResponseDTO Update(MeasuresResponseDTO book);

        //void Delete(long id);

    }
}
