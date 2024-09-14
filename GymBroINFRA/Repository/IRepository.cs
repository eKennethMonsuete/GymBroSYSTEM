using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBroINFRA.Repository
{
    public interface IRepository<T> where T : class
    {

        T Create(T item);

        T FindByID(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        
    }
}
