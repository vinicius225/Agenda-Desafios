using AgendaDesafios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Abstractions
{
    public interface IUserDapperRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById( int id);
        Task<User> GetByLogin(string login);
    }
}
