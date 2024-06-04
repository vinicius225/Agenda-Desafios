using AgendaDesafios.Application.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Calendar.Commands.CalendarUpdateCommand
{
    internal class CalendarUpdateValidation : AbstractValidator<CalendarUpdateCommand>
    {
        public CalendarUpdateValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.ID_IS_REQUIRED);
            RuleFor(x => x.Title).NotEmpty().WithMessage(ValidatorMessages.TITLE_IS_REQUIRED);
            RuleFor(x => x.Description).NotEmpty().WithMessage(ValidatorMessages.DESCRIPTION_IS_REQUIRED);
            RuleFor(x => x.StartEvent).NotEmpty().WithMessage(ValidatorMessages.START_EVENT_IS_REQUIRED);
            RuleFor(x => x.EndEvent).NotEmpty().WithMessage(ValidatorMessages.END_EVENT_IS_REQUIRED)
                                      .GreaterThan(x => x.StartEvent).WithMessage(ValidatorMessages.END_EVENT_MUST_BE_AFTER_START_EVENT);
            RuleFor(x => x.SendEmail).NotNull().WithMessage(ValidatorMessages.SEND_EMAIL_IS_REQUIRED);
            RuleFor(x => x.Status).IsInEnum().WithMessage(ValidatorMessages.STATUS_IS_INVALID);
            RuleFor(x => x.SituationEvent).IsInEnum().WithMessage(ValidatorMessages.SITUATION_EVENT_IS_INVALID);

        }
    }
}
