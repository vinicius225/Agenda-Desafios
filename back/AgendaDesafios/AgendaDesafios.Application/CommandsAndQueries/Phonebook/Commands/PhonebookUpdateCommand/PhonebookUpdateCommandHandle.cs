using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Commands.PhonebookUpdateCommand
{
    public class PhonebookUpdateCommandHandle : IRequestHandler<PhonebookUpdateCommand, Phonebook>
    {
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IAuthService _authService;
        public PhonebookUpdateCommandHandle(IPhonebookRepository phonebookRepository, IAuthService authService)
        {
            _phonebookRepository = phonebookRepository;
            _authService = authService;
        }

        public async Task<Phonebook> Handle(PhonebookUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _phonebookRepository.Update(new Phonebook(
                request.Id,
                request.Name,
                request.Email,
                request.Status,
                request.Phone,
                _authService.GetUserId()
                ));
        }
    }
}
