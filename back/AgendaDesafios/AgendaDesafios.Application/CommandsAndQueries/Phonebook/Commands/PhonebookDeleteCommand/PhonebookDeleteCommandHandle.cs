using AgendaDesafios.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Commands.PhonebookDeleteCommand
{
    public class PhonebookDeleteCommandHandle : IRequestHandler<PhonebookDeleteCommand>
    {
        private readonly IPhonebookRepository _phonebookRepository;

        public PhonebookDeleteCommandHandle(IPhonebookRepository phonebookRepository)
        {
            _phonebookRepository = phonebookRepository;
        }

        public async Task<Unit> Handle(PhonebookDeleteCommand request, CancellationToken cancellationToken)
        {
            await _phonebookRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
