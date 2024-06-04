using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Queries.PhonebookGetAll
{
    public class CalendarQueryAllHandle : IRequestHandler<PhonebookQueryGetAll, IEnumerable<Phonebook>>
    {
        private readonly IPhonebookDapperRepository _phonebookDapperRepository;
        public CalendarQueryAllHandle(IPhonebookDapperRepository phonebookDapperRepository)
        {
            _phonebookDapperRepository = phonebookDapperRepository;
        }
        public async Task<IEnumerable<Phonebook>> Handle(PhonebookQueryGetAll request, CancellationToken cancellationToken)
        {
            return await _phonebookDapperRepository.GetAll();
        }
    }
}
