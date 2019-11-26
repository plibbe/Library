using Library.Web.Entities;
using Library.Web.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private LibraryDbContext _context;

        public CustomerRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
