using EpolSoft.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace EpolSoft.DataAccessLayer
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
