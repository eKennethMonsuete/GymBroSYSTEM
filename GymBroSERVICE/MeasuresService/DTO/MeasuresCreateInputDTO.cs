using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.MeasuresService.DTO
{
    public class MeasuresCreateInputDTO
    {
        public double Weight
        {
            get; set;
        }


        public double RightBiceps
        {
            get; set;
        }


        public double LeftBiceps
        {
            get; set;
        }


        public double Hips
        {
            get; set;
        }
        public double RightQuadriceps
        {
            get; set;
        }
        public double LeftQuadriceps
        {
            get; set;
        }
        public double RightCalf
        {
            get; set;
        }
        public double LeftCalf
        {
            get; set;
        }

        public long UserId
        {
            get; set;
        }
    }
}
