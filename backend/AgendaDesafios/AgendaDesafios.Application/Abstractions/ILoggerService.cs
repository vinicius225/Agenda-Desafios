using AgendaDesafios.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Application.Abstractions
{
    public interface ILoggerService
    {
        Task AddLog(LoggerDTO logDTO);
    }
}
