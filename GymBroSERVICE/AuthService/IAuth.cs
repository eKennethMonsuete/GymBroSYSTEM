using GymBroSERVICE.AuthService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroSERVICE.AuthService
{
    public interface IAuth
    {

        string Login(AuthDTO authDTO); 
    }
}
