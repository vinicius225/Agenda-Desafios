using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDesafios.Infrastructure.Repositories
{
    public class CalendarDapperRepository : ICalendarDapperRepository
    {
        private readonly IDbConnection _connection;

        public CalendarDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Calendar>> GetAll()
        {
            string query = "select * from calendars";
            return await _connection.QueryAsync<Calendar>(query);
        }

        public async Task<IEnumerable<Calendar>> Search(string data)
        {
            string query = "select * from calendars where name like='%@data%'";
            return await _connection.QueryAsync<Calendar>(query, new {data = data});

        }
    }
}
