using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Commands.PhonebookDeleteCommand
{
    public class PhonebookDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
