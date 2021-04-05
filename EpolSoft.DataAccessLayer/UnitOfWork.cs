using System.Threading.Tasks;
using EpolSoft.DataAccessLayer.Interfaces;
using EpolSoft.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace EpolSoft.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IRepository<Customer> _customerRepository;

        public UnitOfWork(DbContext context)
        {
            _context = (DataBaseContext)context;
        }

        public IRepository<Customer> CustomerRepository =>
            _customerRepository ??= new Repository<Customer>(_context.Customers);

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
