using AgendaDesafios.Application.Commands.CalendarAaddCommand;
using AgendaDesafios.Application.Commands.CalendarDeleteCommand;
using AgendaDesafios.Application.Commands.CalendarUpdateCommand;
using AgendaDesafios.Application.Login.Queries;
using AgendaDesafios.Application.Queries.CalendarGetAll;
using AgendaDesafios.Application.Queries.CalendarSearch;
using AgendaDesafios.Application.Queries.PhoneBookSearch;
using AgendaDesafios.WebAPI.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AgendaDesafios.WebAPI.Controllers
{
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
            var response = _mediator.Send(new CalendarQueryGetAll());
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso",await response);
        }
        [HttpGet("{id}")]
        public async Task<IResult> Get([FromHeader] CalendarSearchQuery query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpPost]
        public async Task<IResult> Post(CalendarAddCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpPut]
        public async Task<IResult> Put(CalendarUpdateCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpDelete]
        public async Task<IResult> Delete(CalendarDeleteCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
    }
}
