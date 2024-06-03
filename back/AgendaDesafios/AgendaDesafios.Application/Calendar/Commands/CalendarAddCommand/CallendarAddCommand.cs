using AgendaDesafios.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDesafios.Domain.Entities;

namespace AgendaDesafios.Application.Commands.CalendarAaddCommand
{
    public class CalendarAddCommand : IRequest<Calendar>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartEvent { get; private set; }
        public DateTime EndEvent { get; private set; }
        public bool SendEmail { get; private set; }
        public StatussEnum Status { get; private set; }
        public SituationEventEnum SituationEvent { get; private set; }
    }
}
