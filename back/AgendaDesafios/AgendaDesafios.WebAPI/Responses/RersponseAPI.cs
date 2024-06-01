using System.Net;

namespace AgendaDesafios.WebAPI.Responses
{
    public class ResponseAPI
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

        public static IResult Send(byte[] data)
        {
            IResult response = Results.File(data);

            return response;
        }
    }

}
