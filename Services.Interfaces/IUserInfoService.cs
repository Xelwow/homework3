using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork_API.Models;

namespace HomeWork_API.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);

        Task<User> AppendUser(User user);

        Task<User> LazyAppendUser(User user);
    }

}
