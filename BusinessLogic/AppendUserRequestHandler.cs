using System;
using System.Threading.Tasks;
using HomeWork_API.Models;
using HomeWork_API.Services.Interfaces;
using HomeWork_API.Contracts;
using MassTransit;

namespace HomeWork_API.BusinessLogic
{
    public class AppendUserRequestHandler
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IBus _bus;
        public AppendUserRequestHandler(IUserInfoService userInfoService, IBus bus)
        {
            _userInfoService = userInfoService;
            _bus = bus;
        }
        public Task<User> Handle(User user)
        {
            if (user.username == null || user.city == null)
            {
                throw new ArgumentException("Некорректные данные о пользователе", nameof(user));
            }
            _userInfoService.AppendUser(user);
            return Task.FromResult(user);
        }
        public Task<User> LazyHandle(User user)
        {
            if (user.username == null || user.city == null)
            {
                throw new ArgumentException("Некорректные данные о пользователе", nameof(user));
            }
            _bus.Send(new AppendUserContract() { user = user});

            return Task.FromResult(user);
        }
    }
}
