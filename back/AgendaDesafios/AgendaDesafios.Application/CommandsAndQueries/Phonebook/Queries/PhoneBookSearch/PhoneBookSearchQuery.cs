using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Queries.PhoneBookSearch
{
    public class PhonebookSearchQuery : IRequest<IEnumerable<Phonebook>>
    {
        public string Search { get; set; }
    }
}
