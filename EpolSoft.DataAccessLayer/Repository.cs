using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EpolSoft.DataAccessLayer.Interfaces
{
    class Repository<TEntity> : IRepository<TEntity> 
        where TEntity: class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}