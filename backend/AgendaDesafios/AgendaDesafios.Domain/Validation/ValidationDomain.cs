using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Domain.Validation
{
    internal class ValidationDomain : Exception

    {
        public ValidationDomain(string error) : base(error) { }
        public static void VerificationDomainError(bool Error, string error)
        {
            if (Error)
            {
                throw new ValidationDomain(error);
            }
        }
    }
}
