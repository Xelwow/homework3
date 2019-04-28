using System;
using System.Threading.Tasks;
using HomeWork_API.Models;
using HomeWork_API.Services.Interfaces;

namespace HomeWork_API.BusinessLogic
{
    public class AppendUserRequestHandler
    {
        private readonly IUserInfoService _userInfoService;

        public AppendUserRequestHandler(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        public Task<User> Handle(User user)
        {
            if (user.username == null || user.city == null)
            {
                throw new ArgumentException("Некорректные данные о пользователе", nameof(user));
            }
            return _userInfoService.AppendUser(user);
        }
    }
}
