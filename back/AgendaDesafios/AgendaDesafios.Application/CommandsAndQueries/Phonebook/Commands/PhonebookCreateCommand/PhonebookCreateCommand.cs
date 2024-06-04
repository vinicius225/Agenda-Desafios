using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Commands.PhonebookCreateCommand
{
    public class PhonebookCreateCommand : IRequest<Phonebook>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public StatussEnum Status { get; set; }
    }
}
