using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Queries.PhonebookGetAll
{
    public class PhonebookQueryGetAll : IRequest<IEnumerable<Phonebook>>
    {
    }
}
