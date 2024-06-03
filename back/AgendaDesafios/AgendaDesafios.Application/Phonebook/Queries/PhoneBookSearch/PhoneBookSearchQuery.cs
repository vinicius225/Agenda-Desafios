using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Queries.PhoneBookSearch
{
    public class PhoneBookSearchQuery : IRequest<IEnumerable<Phonebook>>
    {
        public string Search { get; set; }
    }
}
