using AgendaDesafios.Application.Consts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Login.Queries
{
    public class AuthUserValidation : AbstractValidator<AuthUserQuery>
    {
        public AuthUserValidation()
        {
            RuleFor(a => a.Login).NotEmpty().WithMessage(ValidatorMessages.LOGIN_IS_REQUIRED);
            RuleFor(a => a.Password).NotEmpty().WithMessage(ValidatorMessages.PASSWORD_IS_REQUIRED);
        }
    }
}
