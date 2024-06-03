using AgendaDesafios.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.DTOs.Auth;
using AgendaDesafios.Application.Validations;

namespace AgendaDesafios.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IResult> Authentication(AuthLoginDTO auth)
        {
            var validation =new AuthLoginValidation();
            var requestValidation = validation.Validate(auth);
            if (!requestValidation.IsValid)
            {
                return ResponseAPI.Send(requestValidation.Errors);
            }
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso",await _authService.AuthLogin(auth));
        }
    }
}
