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
            var result = await _connection.QueryAsync<User>(query);
            return result;
        }

        public async Task<User> GetById(int id)
        {
            string query = "SELECT * FROM USERS WHERE ID=@id";
            var  result = await  _connection.QueryFirstOrDefaultAsync<User>(query, id);
            if (result == null)
            {
                throw new KeyNotFoundException();
            }
            return result;

        }
        public async Task<User> GetByLogin(string login)
        {
            try
            {
                string query = "SELECT Id, Name, Email, Status, Password, Created, Updated FROM Schedule.dbo.Users WHERE Email=@login";
                var result = await _connection.QueryFirstOrDefaultAsync<User>(query, new { login = login });
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
