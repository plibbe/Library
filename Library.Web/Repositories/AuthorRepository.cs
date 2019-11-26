using Library.Web.Entities;
using Library.Web.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Author item)
        {
            if (item == null)
                throw new ArgumentNullException();

            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _context.Authors.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> FindByIdAsync(int id)
        {
            if (id == 0)
                throw new ArgumentException();

            return await _context.Authors.FindAsync(id);
        }

        public IAsyncEnumerable<Author> GetAll() => _context.Authors.ToAsyncEnumerable();


        public async Task UpdateAsync(Author item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
