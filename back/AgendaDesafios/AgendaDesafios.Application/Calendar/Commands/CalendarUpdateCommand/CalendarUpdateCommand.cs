using AgendaDesafios.Domain.Entities;
using AgendaDesafios.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Commands.CalendarUpdateCommand
{
    public class CalendarUpdateCommand : IRequest<Calendar>
    {
        public int Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime StartEvent { get;  set; }
        public DateTime EndEvent { get;  set; }
        public bool SendEmail { get;  set; }
        public StatussEnum Status { get;  set; }
        public SituationEventEnum SituationEvent { get;  set; }
    }
}
