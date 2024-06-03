using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Commands.PhonebookCreateCommand
{
    public class PhonebookCreateCommandHandle : IRequestHandler<PhonebookCreateCommand, Phonebook>
    {
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IAuthService _authService;
        public PhonebookCreateCommandHandle(IPhonebookRepository phonebookRepository)
        {
            _phonebookRepository = phonebookRepository;
        }

        public async Task<Phonebook> Handle(PhonebookCreateCommand request, CancellationToken cancellationToken)
        {
            return await _phonebookRepository.Add(new Phonebook(
                request.Name,
                request.Email,
                request.Status,
                request.Phone,
                _authService.GetUserId()
                ));
        }
    }
}
