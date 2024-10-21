using GymBroINFRA.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;

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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T FindByID(long id)
        {
            try
            {
                var entity = dbSet.Find(id);

                
                if (entity == null)
                {
                    throw new KeyNotFoundException($"Entity with ID {id} was not found.");
                }

                return entity;
            }
            catch (KeyNotFoundException ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw new Exception("An error occurred while fetching the entity.");
            }
        }

        public T FindByEmail(string email)
        {
            var entity = dbSet.FirstOrDefault(e => EF.Property<string>(e, "Email") == email);

            return entity;
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

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
           var result = await  _context.SaveChangesAsync();
            if (result == 0)
            {
                throw new Exception("Falha ao salvar a entidade no banco de dados.");
            }

            return entity;
        }

        public void Delete(long id)
        {
            var entity = dbSet.SingleOrDefault(e => EF.Property<long>(e, "Id") == id);

            if (entity == null)
            {
                throw new KeyNotFoundException("A entidade com o ID fornecido não foi encontrada.");
            }

            try
            {
                dbSet.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Aqui você pode capturar e tratar outras exceções que possam ocorrer
                throw new InvalidOperationException("Falha ao tentar deletar a entidade.", ex);
            }

        }

        public T Update(T item)
        {
            // Assumindo que T tem uma propriedade Id do tipo long
            var keyProperty = typeof(T).GetProperty("Id");
            if (keyProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an 'Id' property.");
            }

            var itemId = (long)keyProperty.GetValue(item); // Converta para long, ajustando conforme o tipo da chave
            var result = dbSet.Find(itemId); // Use Find para obter a entidade com base no ID

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
                throw new KeyNotFoundException("Entity with the given Id was not found.");
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                {
                    return dbSet.Where(filter).AsNoTracking();
                }
            }
            return null;
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }
    }
}
