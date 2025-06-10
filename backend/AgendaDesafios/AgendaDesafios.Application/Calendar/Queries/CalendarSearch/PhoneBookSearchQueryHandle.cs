using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.CalendarSearch
{
    public class CalendarQueryHandle : IRequestHandler<CalendarSearchQuery, IEnumerable<Calendar>>
    {
        private readonly ICalendarDapperRepository _calendarDapperRepository;
        public CalendarQueryHandle(ICalendarDapperRepository calendarDapperRepository)
        {
            _calendarDapperRepository = calendarDapperRepository;
        }

        public async Task<IEnumerable<Calendar>> Handle(CalendarSearchQuery request, CancellationToken cancellationToken)
        {
            return await _calendarDapperRepository.Search(request.Search);
        }
    }
}
