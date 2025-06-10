using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.CalendarGetAll
{
    public class CalendarQueryAllHandle : IRequestHandler<CalendarQueryGetAll, IEnumerable<Calendar>>
    {
        private readonly ICalendarDapperRepository _calendarDapperRepository;

        public CalendarQueryAllHandle(ICalendarDapperRepository calendarDapperRepository)
        {
            _calendarDapperRepository = calendarDapperRepository;
        }

        public async Task<IEnumerable<Calendar>> Handle(CalendarQueryGetAll request, CancellationToken cancellationToken)
        {
          return await _calendarDapperRepository.GetAll();
        }
    }
}
