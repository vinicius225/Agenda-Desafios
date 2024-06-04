using AgendaDesafios.Application.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Phonebook.Commands.PhonebookCreateCommand
{
    internal class PhonebookCommandValidation : AbstractValidator<PhonebookCreateCommand>
    {
        public PhonebookCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidatorMessages.NAME_IS_REQUIRED);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidatorMessages.EMAIL_IS_REQUIRED);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ValidatorMessages.PHONE_IS_REQUIRED);
            RuleFor(x => x.Status).IsInEnum().WithMessage(ValidatorMessages.STATUS_IS_INVALID);
        }
    }
}
