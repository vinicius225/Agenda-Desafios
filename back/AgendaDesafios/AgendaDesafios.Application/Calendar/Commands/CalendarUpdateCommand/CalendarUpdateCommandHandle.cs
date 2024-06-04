using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Commands.CalendarUpdateCommand
{
    public class CalendarUpdateCommandHandle : IRequestHandler<CalendarUpdateCommand, Calendar>
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly IAuthService _authService;

        public CalendarUpdateCommandHandle(ICalendarRepository calendarRepository, IAuthService authService)
        {
            _calendarRepository = calendarRepository;
            _authService = authService;
        }

        public async Task<Calendar> Handle(CalendarUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _calendarRepository.Update(new Calendar(
                request.Id,
                request.Title,
                request.Description,
                request.StartEvent,
                request.EndEvent,
                request.SendEmail,
                request.Status,
                request.SituationEvent,
                _authService.GetUserId()
                ));
        }
    }
}
