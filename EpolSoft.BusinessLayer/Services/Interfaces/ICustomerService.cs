using System.Collections.Immutable;
using System.Threading.Tasks;
using EpolSoft.BusinessLayer.Entities;

namespace EpolSoft.BusinessLayer.Services
{
    public interface ICustomerService
    {
        Task<Customer> Add(Customer customer);
        IImmutableList<Customer> GetAll();
        Task<Customer> Update(Customer customer);
        Task<Customer> UpdateOptional(Customer customer);
    }
}