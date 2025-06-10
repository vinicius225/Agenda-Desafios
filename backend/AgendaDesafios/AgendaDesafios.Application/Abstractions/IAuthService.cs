using AgendaDesafios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Abstractions
{
    public interface IAuthService
    {
        int GetUserId();
        string GenerateToke(User user);
        string PasswordHash(string password);
    }
}
