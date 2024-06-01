using AgendaDesafios.Domain.Consts;
using AgendaDesafios.Domain.Enums;
using AgendaDesafios.Domain.Validation;
using System;
using System.Linq;

namespace AgendaDesafios.Domain.Entities
{
    public class Calendar
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartEvent { get; private set; }
        public DateTime EndEvent { get; private set; }
        public bool SendEmail { get; private set; }
        public StatussEnum Status { get; private set; }
        public SituationEventEnum SituationEvent { get; private set; }
        public int IdUser { get; private set; }
        public virtual User User { get; private set; }

        public Calendar(string title, string description, DateTime startEvent, DateTime endEvent, bool sendEmail, StatussEnum status, SituationEventEnum situationEvent, int idUser)
        {
            ValidateCalendar(title, description, startEvent, endEvent, sendEmail, status, situationEvent, idUser);
        }

        public Calendar(int id, string title, string description, DateTime startEvent, DateTime endEvent, bool sendEmail, StatussEnum status, SituationEventEnum situationEvent, int idUser)
        {
            ValidationDomain.VerificationDomainError(id < 0, DomainErrosConsts.ID_INVALID);
            Id = id;
            ValidateCalendar(title, description, startEvent, endEvent, sendEmail, status, situationEvent, idUser);
        }

        private void ValidateCalendar(string title, string description, DateTime startEvent, DateTime endEvent, bool sendEmail, StatussEnum status, SituationEventEnum situationEvent,int idUser)
        {
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(title), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(title.Length < 3, DomainErrosConsts.MIN_LENGTH);
            ValidationDomain.VerificationDomainError(endEvent >= startEvent,DomainErrosConsts.DATAE_END_GTN_DATE_START);
            ValidationDomain.VerificationDomainError(description.Length > 500, DomainErrosConsts.EXCEDED_CHARACTER_LIMIT);

            Title = title;
            Description = description;
            StartEvent = startEvent;
            EndEvent = endEvent;
            SendEmail = sendEmail;
            Status = status;
            SituationEvent = situationEvent;
        }
    }
}
