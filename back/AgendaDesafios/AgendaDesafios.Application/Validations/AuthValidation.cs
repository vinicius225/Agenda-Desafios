using AgendaDesafios.Application.Consts;
using AgendaDesafios.Application.DTOs.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Validations
{
    public class AuthLoginValidation : AbstractValidator<AuthLoginDTO>
    {
        public AuthLoginValidation()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage(DTOsMessages.LOGIN_IS_REQUIRED);
            RuleFor(x => x.Password).NotEmpty().WithMessage(DTOsMessages.PASSWORD_IS_REQUIRED);
        }
    }
}
