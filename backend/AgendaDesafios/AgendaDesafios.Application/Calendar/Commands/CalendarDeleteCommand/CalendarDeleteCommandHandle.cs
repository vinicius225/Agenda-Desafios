using AgendaDesafios.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Commands.CalendarDeleteCommand
{
    public class CalendarDeleteCommandHandle : IRequestHandler<CalendarDeleteCommand>
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarDeleteCommandHandle(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task<Unit> Handle(CalendarDeleteCommand request, CancellationToken cancellationToken)
        {
            await _calendarRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
