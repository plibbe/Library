using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task<T> FindByIdAsync(int id);

        IAsyncEnumerable<T> GetAll();
    }
}
