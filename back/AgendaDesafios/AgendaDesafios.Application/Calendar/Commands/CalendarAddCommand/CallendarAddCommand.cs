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
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime StartEvent { get;  set; }
        public DateTime EndEvent { get;  set; }
        public bool SendEmail { get;  set; }
        public StatussEnum Status { get;  set; }
        public SituationEventEnum SituationEvent { get;  set; }
    }
}
