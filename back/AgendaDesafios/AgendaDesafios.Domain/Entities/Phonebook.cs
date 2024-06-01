using AgendaDesafios.Domain.Consts;
using AgendaDesafios.Domain.Enums;
using AgendaDesafios.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AgendaDesafios.Domain.Entities
{
    public class Phonebook
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public StatussEnum Status { get; private set; }
        public int IdUser { get; private set; }

        public virtual User User { get; private set; }

        public  Phonebook(string name, string email, StatussEnum status, string phone, int  idUser )
        {
            ValidationEntity( name, email, status, phone, idUser );
        }
        public Phonebook(int id, string name, string email, StatussEnum status, string phone, int idUser)
        {
            ValidationDomain.VerificationDomainError(id < 0, DomainErrosConsts.ID_INVALID);
            Id = id;
            ValidationEntity(name, email, status, phone, idUser);

        }

        public void ValidationEntity(string name, string email, StatussEnum status, string phone, int idUser)
        {
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(name), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(name.Length < 3, DomainErrosConsts.MIN_LENGTH);
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(email), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(!email.Contains("@"), DomainErrosConsts.NOT_IS_EMAIL); 
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(phone), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(phone.Any(char.IsLetter), DomainErrosConsts.NOT_IS_PHONE);
            ValidationDomain.VerificationDomainError(idUser < 0, DomainErrosConsts.ID_INVALID);



            Name = name;
            Email = email;
            Status = status;
            Phone = phone;
            IdUser = idUser;
        }

    }


}
