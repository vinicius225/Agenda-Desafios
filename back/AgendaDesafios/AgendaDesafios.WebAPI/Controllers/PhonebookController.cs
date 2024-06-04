using AgendaDesafios.Application.Commands.PhonebookCreateCommand;
using AgendaDesafios.Application.Commands.PhonebookDeleteCommand;
using AgendaDesafios.Application.Commands.PhonebookUpdateCommand;
using AgendaDesafios.Application.Queries.PhonebookGetAll;
using AgendaDesafios.Application.Queries.PhoneBookSearch;
using AgendaDesafios.WebAPI.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AgendaDesafios.WebAPI.Controllers
{
    [Authorize]
    [Route("api/phonebook")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhonebookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var response = _mediator.Send(new PhonebookQueryGetAll());
                if (response == null)
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);

            }
            catch (Exception ex)
            {
                return ResponseAPI.Send(System.Net.HttpStatusCode.ServiceUnavailable, "Erro naa plataforma");

            }
        }
        [HttpGet("{query}")]
        public async Task<IResult> Get(string query)
        {
            try
            {
                var response = _mediator.Send(new PhonebookSearchQuery { Search = query });
                if (response == null)
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
            }
            catch (Exception ex)
            {
                return ResponseAPI.Send(System.Net.HttpStatusCode.ServiceUnavailable, "Erro naa plataforma");

            }
        }
        [HttpPost]
        public async Task<IResult> Post(PhonebookCreateCommand query)
        {
            try
            {
                var response = _mediator.Send(query);
                if (response == null)
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
            }
            catch (Exception ex)
            {
                return ResponseAPI.Send(System.Net.HttpStatusCode.ServiceUnavailable, "Erro naa plataforma");

            }
        }
        [HttpPut]
        public async Task<IResult> Put(PhonebookUpdateCommand query)
        {
            try
            {
                var response = _mediator.Send(query);
                if (response == null)
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
            }
            catch (Exception ex)
            {
                return ResponseAPI.Send(System.Net.HttpStatusCode.ServiceUnavailable, "Erro naa plataforma");

            }
        }
        [HttpDelete("{id}")]
        public async Task<IResult> Delete([FromQuery] int id)
        {
            try
            {
                var response = _mediator.Send(new PhonebookDeleteCommand { Id = id });
                if (response == null)
                {
                    return ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Parametros invalidos");
                }
                return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
            }
            catch (Exception ex)
            {
                return ResponseAPI.Send(System.Net.HttpStatusCode.ServiceUnavailable, "Erro naa plataforma");

            }
        }
    }
}
