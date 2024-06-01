using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Consts
{
    public static  class DomainErrosConsts
    {
        public const string ID_INVALID = "Id passado é inválido.";
        public const string INPUT_IS_EMPTY = "Id passado vazio.";
        public const string MIN_LENGTH = "Quantidade mínima de caracteres não atendida";
        public const string NOT_IS_EMAIL = "O valor passado não se trata de um e-mail.";
        public const string NOT_IS_PHONE = "O valor passado não se trata de um telefone.";
        public const string DATAE_END_GTN_DATE_START = "Data final maior que a data inicial";
        public const string EXCEDED_CHARACTER_LIMIT = "Data final maior que a data inicial";
    }
}
