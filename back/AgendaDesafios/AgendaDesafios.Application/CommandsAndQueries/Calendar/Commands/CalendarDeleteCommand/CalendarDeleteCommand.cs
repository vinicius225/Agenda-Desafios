using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Calendar.Commands.CalendarDeleteCommand
{
    public class CalendarDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
