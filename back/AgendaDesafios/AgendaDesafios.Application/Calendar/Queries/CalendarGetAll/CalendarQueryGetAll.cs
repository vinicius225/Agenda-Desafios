using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.CalendarGetAll
{
    public class CalendarQueryGetAll : IRequest<IEnumerable<Calendar>>
    {
    }
}
