using AgendaDesafios.Domain.Abstractions;
using AgendaDesafios.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AgendaDesafios.Infrastructure.Repositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly IDbConnection _connection;

        public UserDapperRepository(IDbConnection connection)
        {

            this._connection = connection;

        }
        public async Task<IEnumerable<User>> GetAll()
        {
            string query = "select * from users";
            return await _connection.QueryAsync<User>(query);
        }

        public async Task<User> GetById(int id)
        {
            string query = "SELECT * FROM USERS WHERE ID=@id";
            return await _connection.QueryFirstAsync<User>(query, id);

        }
        public async Task<User> GetByLogin(string login)
        {
            string query = "SELECT * FROM USERS WHERE Login=@login";
            return await _connection.QueryFirstAsync<User>(query, new {login=login});
        }
    }
}
