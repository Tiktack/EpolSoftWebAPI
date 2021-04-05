using System.Linq;
using System.Threading.Tasks;

namespace EpolSoft.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        public IQueryable<TEntity> Get();
        public TEntity Add(TEntity entity);
        public TEntity Delete(TEntity entity);
        public TEntity Update(TEntity entity);
    }
}
