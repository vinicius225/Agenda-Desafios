using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.PhonebookGetAll
{
    public class PhonebookQueryAllHandle : IRequestHandler<PhonebookQueryGetAll, IEnumerable<Phonebook>>
    {
        private readonly IPhonebookDapperRepository _phonebookDapperRepository;
        public PhonebookQueryAllHandle(IPhonebookDapperRepository phonebookDapperRepository)
        {
            _phonebookDapperRepository = phonebookDapperRepository;
        }
        public async Task<IEnumerable<Phonebook>> Handle(PhonebookQueryGetAll request, CancellationToken cancellationToken)
        {
          return await  _phonebookDapperRepository.GetAll();
        }
    }
}
