using AgendaDesafios.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Application.Abstractions;

namespace AgendaDesafios.Application.Commands.CalendarAaddCommand
{
    public class CalendarAddCommandHandle : IRequestHandler<CalendarAddCommand, Calendar>
    {
        private readonly ICalendarRepository _repository;
        private readonly IAuthService _authService;
        public CalendarAddCommandHandle(ICalendarRepository repository)
        {
            _repository = repository;
        }

        public async Task<Calendar> Handle(CalendarAddCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Add(new Calendar(
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
