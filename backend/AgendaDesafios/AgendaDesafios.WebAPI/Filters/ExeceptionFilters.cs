using AgendaDesafios.Application.Abstractions;
using AgendaDesafios.Application.Exceptions;
using AgendaDesafios.Application.Services;
using AgendaDesafios.WebAPI.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgendaDesafios.WebAPI.Filters
{
    public class ExeceptionFilters : IExceptionFilter
    {
   

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not FluentValidation.ValidationException &&
                context.Exception is not ServicesExceptions)
            {
                //_loggerService.AddLog(new Application.DTOs.LoggerDTO { Controler = context.RouteData.ToString(), Object = context.ModelState, Ex = context.Exception });
            }

            if (context.Exception is FluentValidation.ValidationException ex)
            {
                context.Result = new ObjectResult(ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Dados inválidos", ex.Errors.Select(a => a.ErrorMessage)));

            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                context.Result = new ObjectResult(ResponseAPI.Send(System.Net.HttpStatusCode.BadRequest, "Dados inválidos", messages));
            }
        }
    }
}
