
using GymBroAPPLICATION.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.Service
{
    public interface IMeasuresService
    {
        MeasuresDTO Create(MeasuresDTO measures);
        MeasuresDTO FindByID(long id);

        List<MeasuresDTO> FindAll();

        MeasuresDTO Update(MeasuresDTO book);

        void Delete(long id);

    }
}
