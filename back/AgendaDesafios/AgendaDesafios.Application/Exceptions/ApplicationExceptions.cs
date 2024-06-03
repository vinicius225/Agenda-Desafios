using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Exceptions
{
    public  class ApplicationExceptions : Exception
    {
        public  ApplicationExceptions(string error) : base(error)
        {
        }
        public static void Error(string error)
        {

            throw new ApplicationExceptions(error);
        }

    }
}
