using AgendaDesafios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Abstractions
{
    public interface ICalendarDapperRepository 
    {
        Task<IEnumerable<Calendar>> GetAll();
        Task<IEnumerable<Calendar>> Search(string data);
    }
}
