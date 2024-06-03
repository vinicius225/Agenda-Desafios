﻿using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Commands.PhonebookUpdateCommand
{
    public class PhonebookUpdateCommand : IRequest<Phonebook>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public StatussEnum Status { get; private set; }
    }

}