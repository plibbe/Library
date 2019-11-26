using Library.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public Task AddAsync(Book item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book item)
        {
            throw new NotImplementedException();
        }

        public Task<Book> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
