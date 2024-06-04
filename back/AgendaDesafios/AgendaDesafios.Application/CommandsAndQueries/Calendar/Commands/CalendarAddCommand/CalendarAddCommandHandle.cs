using AgendaDesafios.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Application.Abstractions;

namespace AgendaDesafios.Application.CommandsAndQueries.Calendar.Commands.CalendarAddCommand
{
    public class CalendarAddCommandHandle : IRequestHandler<CalendarAddCommand, Calendar>
    {
        private readonly ICalendarRepository _repository;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IUserDapperRepository _userDapperRepository;
        public CalendarAddCommandHandle(ICalendarRepository repository, IEmailService emailService, IUserDapperRepository userDapperRepository, IAuthService authService)
        {
            _repository = repository;
            _emailService = emailService;
            _userDapperRepository = userDapperRepository;
            _authService = authService;
        }

        public async Task<Calendar> Handle(CalendarAddCommand request, CancellationToken cancellationToken)
        {
            if (request.SendEmail)
            {
                var user = await _userDapperRepository.GetById(_authService.GetUserId());
                await _emailService.SendEmail(user.Email, request.Title, request.Description);
            }

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
