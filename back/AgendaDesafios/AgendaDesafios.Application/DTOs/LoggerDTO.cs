using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.DTOs
{
    public class LoggerDTO
    {
        public Object Object { get; set; }
        public Exception Ex { get; set; }
        public string Controler { get; set; }
    }
}
