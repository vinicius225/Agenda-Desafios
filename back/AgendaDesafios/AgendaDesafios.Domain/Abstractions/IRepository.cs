using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> Update(T obj);
        Task<T> Add(T  obj);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAsync();
    }
}
