using AgendaDesafios.Domain.Consts;
using AgendaDesafios.Domain.Enums;
using AgendaDesafios.Domain.Validation;
using System;

namespace AgendaDesafios.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public StatussEnum Status { get; private set; }
        public string Password { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public IEnumerable<Phonebook> Phonebook { get; private set; }
        public IEnumerable<Calendar> Calendar { get; private set; }

        public User(string name, string email, string password, StatussEnum status)
        {
            ValidateUser(name, email, password, status);
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }

        public User(int id, string name, string email, string password, StatussEnum status, DateTime created, DateTime updated)
        {
            ValidationDomain.VerificationDomainError(id < 0, DomainErrosConsts.ID_INVALID);
            Id = id;
            ValidateUser(name, email, password, status);
            Created = created;
            Updated = updated;
        }

        private void ValidateUser(string name, string email, string password, StatussEnum status)
        {
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(name), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(name.Length < 3, DomainErrosConsts.MIN_LENGTH);
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(email), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(!email.Contains("@"), DomainErrosConsts.NOT_IS_EMAIL);
            ValidationDomain.VerificationDomainError(string.IsNullOrWhiteSpace(password), DomainErrosConsts.INPUT_IS_EMPTY);
            ValidationDomain.VerificationDomainError(password.Length < 6, DomainErrosConsts.MIN_LENGTH);

            Name = name;
            Email = email;
            Password = password;
            Status = status;
        }
    }
}
