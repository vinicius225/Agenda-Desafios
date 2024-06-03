using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.PhoneBookSearch
{
    public class PhoneBookSearchQueryHandle : IRequestHandler<PhoneBookSearchQuery, IEnumerable<Phonebook>>
    {
        private readonly IPhonebookDapperRepository _phonebookDapperRepository;
        public PhoneBookSearchQueryHandle(IPhonebookDapperRepository phonebookDapperRepository)
        {
            _phonebookDapperRepository = phonebookDapperRepository;
        }
        public async Task<IEnumerable<Phonebook>> Handle(PhoneBookSearchQuery request, CancellationToken cancellationToken)
        {
            return await _phonebookDapperRepository.Search(request.Search);
        }
    }
}
