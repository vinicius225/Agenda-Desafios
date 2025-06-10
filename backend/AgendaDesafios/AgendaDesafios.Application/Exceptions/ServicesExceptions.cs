using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Exceptions
{
    public class ServicesExceptions : Exception
    {
        public ServicesExceptions(string error) : base(error) { }
        public static void Error(HttpStatusCode Error, string error)
        { 
                throw new ServicesExceptions(error);
            
        }
    }
}
