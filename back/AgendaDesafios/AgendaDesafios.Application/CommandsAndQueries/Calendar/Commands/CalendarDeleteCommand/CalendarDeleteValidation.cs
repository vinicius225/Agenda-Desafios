using AgendaDesafios.Application.Commands.CalendarUpdateCommand;
using AgendaDesafios.Application.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Calendar.Commands.CalendarDeleteCommand
{
    public class CalendarDeleteValidation : AbstractValidator<CalendarDeleteCommand>
    {
        public CalendarDeleteValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ValidatorMessages.ID_IS_REQUIRED);

        }
    }
}
