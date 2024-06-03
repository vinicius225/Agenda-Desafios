﻿using AgendaDesafios.Application.Commands.PhonebookCreateCommand;
using AgendaDesafios.Application.Commands.PhonebookDeleteCommand;
using AgendaDesafios.Application.Commands.PhonebookUpdateCommand;
using AgendaDesafios.Application.Queries.PhonebookGetAll;
using AgendaDesafios.Application.Queries.PhoneBookSearch;
using AgendaDesafios.WebAPI.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace AgendaDesafios.WebAPI.Controllers
{
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
            var response = _mediator.Send(new PhonebookQueryGetAll());
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpGet("{id}")]
        public async Task<IResult> Get([FromHeader] PhonebookSearchQuery query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpPost]
        public async Task<IResult> Post(PhonebookCreateCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpPut]
        public async Task<IResult> Put(PhonebookUpdateCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
        [HttpDelete]
        public async Task<IResult> Delete(PhonebookDeleteCommand query)
        {
            var response = _mediator.Send(query);
            return ResponseAPI.Send(System.Net.HttpStatusCode.OK, "Sucesso", await response);
        }
    }
}
