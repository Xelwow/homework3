using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWork_API.BusinessLogic;
using HomeWork_API.Models;

namespace HomeWork_API.Controllers
{

    [Route("api/users/")]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;
        private readonly AppendUserRequestHandler _appendUserRequestHandler;
        public UsersController(GetUsersInfoRequestHandler getUsersInfoRequestHandler, AppendUserRequestHandler appendUserRequestHandler)
        {
            _getUsersInfoRequestHandler = getUsersInfoRequestHandler;
            _appendUserRequestHandler = appendUserRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }

        [HttpPost("append")]
        public Task<User> AppendUser([FromBody] User user)
        {
            user.id = Guid.NewGuid();

            return _appendUserRequestHandler.Handle(user);
        }
    }

}
