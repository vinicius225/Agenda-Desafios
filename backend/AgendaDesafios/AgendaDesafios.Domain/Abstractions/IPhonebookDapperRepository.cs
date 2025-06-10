using AgendaDesafios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Abstractions
{
    public interface IPhonebookDapperRepository
    {
        Task<IEnumerable<Phonebook>> GetAll();
        Task<IEnumerable<Phonebook>> Search(string data);
    }
}
