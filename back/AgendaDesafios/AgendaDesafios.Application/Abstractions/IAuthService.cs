using AgendaDesafios.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Abstractions
{
    public interface IAuthService
    {
        Task<AuthLoginResponseDTO> AuthLogin(AuthLoginDTO authLoginDTO);
    }
}
