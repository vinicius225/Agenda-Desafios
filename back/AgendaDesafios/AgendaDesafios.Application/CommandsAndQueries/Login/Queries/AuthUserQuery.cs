using AgendaDesafios.Application.DTOs;
using AgendaDesafios.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.CommandsAndQueries.Login.Queries
{
    public class AuthUserQuery : IRequest<AuthDTO>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
