using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Consts
{
    public static class ValidatorMessages
    {
        public const string ID_IS_REQUIRED = "ID é obrigátorio";
        public const string LOGIN_IS_REQUIRED = "Login é obrigátorio";
        public const string EMAIL_IS_REQUIRED = "E-amil é obrigátorio";
        public const string PHONE_IS_REQUIRED = "Telefone é obrigátorio";
        public const string PASSWORD_IS_REQUIRED = "Senha é obrigátorio";
        public const string TITLE_IS_REQUIRED = "O título é obrigatório.";
        public const string NAME_IS_REQUIRED = "O nome é obrigatório.";
        public const string DESCRIPTION_IS_REQUIRED = "A descrição é obrigatória.";
        public const string START_EVENT_IS_REQUIRED = "A data de início do evento é obrigatória.";
        public const string END_EVENT_IS_REQUIRED = "A data de término do evento é obrigatória.";
        public const string END_EVENT_MUST_BE_AFTER_START_EVENT = "A data de término do evento deve ser posterior à data de início.";
        public const string SEND_EMAIL_IS_REQUIRED = "A opção de enviar e-mail é obrigatória.";
        public const string STATUS_IS_INVALID = "O status do evento é inválido.";
        public const string SITUATION_EVENT_IS_INVALID = "A situação do evento é inválida.";
    }
}
