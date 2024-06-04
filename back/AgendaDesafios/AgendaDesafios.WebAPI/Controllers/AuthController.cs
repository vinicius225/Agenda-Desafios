using AgendaDesafios.Application.Login.Queries;
using AgendaDesafios.WebAPI.Responses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AgendaDesafios.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IResult> Authentication(AuthUserQuery auth)
        {
            try
            {
                var response =await  _mediator.Send(auth);
                if(response == null) 
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
