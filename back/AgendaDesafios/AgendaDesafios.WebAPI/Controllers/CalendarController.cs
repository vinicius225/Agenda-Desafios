using AgendaDesafios.Application.Commands.CalendarAaddCommand;
using AgendaDesafios.Application.Commands.CalendarDeleteCommand;
using AgendaDesafios.Application.Commands.CalendarUpdateCommand;
using AgendaDesafios.Application.Login.Queries;
using AgendaDesafios.Application.Queries.CalendarGetAll;
using AgendaDesafios.Application.Queries.CalendarSearch;
using AgendaDesafios.Application.Queries.PhoneBookSearch;
using AgendaDesafios.WebAPI.Responses;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace AgendaDesafios.WebAPI.Controllers
{
    [Authorize]
    [Route("api/calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var response = _mediator.Send(new CalendarQueryGetAll());
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
        public async Task<IResult> Get([FromQuery] string query)
        {
            try
            {
                var response = _mediator.Send(new CalendarSearchQuery() { Search = query });
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
        public async Task<IResult> Post(CalendarAddCommand query)
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
        public async Task<IResult> Put(CalendarUpdateCommand query)
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
                var response = _mediator.Send(new CalendarDeleteCommand() { Id = id });
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
