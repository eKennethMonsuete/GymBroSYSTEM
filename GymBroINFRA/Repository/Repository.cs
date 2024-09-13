using GymBroINFRA.Context;
using Microsoft.EntityFrameworkCore;

namespace GymBroINFRA.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private MySQLContext _context;

        private DbSet<T> dbSet;

        public Repository(MySQLContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dbSet.ToList();
        }

        public T FindByID(long id)
        {
            throw new NotImplementedException();
        }


        public T Create(T item)
        {
            try
            {
                dbSet.Add(item);
                _context.SaveChanges();
                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(long id)
        {
           var result = dbSet.SingleOrDefault(p => p.Equals(id));
            if (result != null)
            {
                try
                {
                    dbSet.Remove(result);
                    _context.SaveChanges();


                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }



        public T Update(T item)
        {
            // Supondo que T tenha uma propriedade Id
            var keyProperty = typeof(T).GetProperty("Id");
            if (keyProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an 'Id' property.");
            }

            var itemId = keyProperty.GetValue(item);
            var result = dbSet.SingleOrDefault(p => keyProperty.GetValue(p).Equals(itemId));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception ex)
                {
                    // Consider logging the exception
                    throw new InvalidOperationException("Update operation failed.", ex);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
