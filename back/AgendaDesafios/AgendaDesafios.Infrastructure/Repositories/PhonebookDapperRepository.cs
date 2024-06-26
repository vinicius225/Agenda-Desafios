﻿using AgendaDesafios.Domain.Abstractions;
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
    public class PhonebookDapperRepository : IPhonebookDapperRepository
    {
        private readonly IDbConnection _connection;

        public PhonebookDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Phonebook>> GetAll()
        {
            string query = "select * from phonebooks where status != 0";
            return await _connection.QueryAsync<Phonebook>(query);
        }

        public async Task<IEnumerable<Phonebook>> Search(string data)
        {
            string query = "select * from phonebooks where name like '%@data%' and status != 0";
            return await _connection.QueryAsync<Phonebook>(query, new { data = data });

        }
    }
}
