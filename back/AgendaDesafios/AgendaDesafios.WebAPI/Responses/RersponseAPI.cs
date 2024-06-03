using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace AgendaDesafios.WebAPI.Responses
{
    public  class ResponseAPI
    {
        public static IResult Send(HttpStatusCode httpStatusCode, string message, object? data = null)
        {
            IResult response;

            if (data != null)
            {
                response = Results.Json(
                    new
                    {
                        httpStatusCode,
                        message,
                        result = data,
                    },
                    statusCode: (int)httpStatusCode
                );
            }
            else
            {
                response = Results.Json(
                    new
                    {
                        httpStatusCode,
                        message
                    },
                    statusCode: (int)httpStatusCode
                );
            }

            return response;
        }
        public static IResult Send(List<ValidationFailure> erros)
        {
            IResult response;


                response = Results.Json(
                    new
                    {
                        httpStatusCode = HttpStatusCode.BadRequest,
                        message = "Parametros invalidos",
                        result = erros.Select(a=> a.ErrorMessage),
                    },
                    statusCode: (int)HttpStatusCode.BadRequest
                );
            

            return response;
        }

        public static IResult Send(FluentValidation.Results.ValidationResult data)
        {
            IResult response;
            var errors = data.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });


                response = Results.Json(
                    new
                    {
                        httpStatusCode= HttpStatusCode.BadRequest,
                       message = "Parametros invalidos",
                        result = errors,
                    },
                    statusCode: 400
                );
            

            return response;
        }


        public static IResult Send(byte[] data)
        {
            IResult response = Results.File(data);

            return response;
        }
    }

}
