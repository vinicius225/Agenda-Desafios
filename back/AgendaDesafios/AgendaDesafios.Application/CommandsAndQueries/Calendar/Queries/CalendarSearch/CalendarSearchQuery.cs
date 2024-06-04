using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Calendar.Queries.CalendarSearch
{
    public class CalendarSearchQuery : IRequest<IEnumerable<Calendar>>
    {
        public string Search { get; set; }
    }
}
