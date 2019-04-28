using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork_API.Services.Interfaces;
using HomeWork_API.Models;
using Npgsql;
using Dapper;

namespace HomeWork_API.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=postgres;username=postgres;password=213";

        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * from \"SomeScheme\".users where id = @id", new {id});
            }
        }
        public async Task<User> AppendUser(User user)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>("insert into \"SomeScheme\".users (id, username, city) values (@id, @username, @city)", user);
            }
        }
    }

}
