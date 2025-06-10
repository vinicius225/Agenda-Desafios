using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendEmail(string Email, string Title,string Body,  IEnumerable<string>? Cc = null);
    }
}
