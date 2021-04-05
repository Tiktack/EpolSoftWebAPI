using System.Threading.Tasks;
using EpolSoft.DataAccessLayer.Model;

namespace EpolSoft.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        Task SaveAsync();
    }
}
