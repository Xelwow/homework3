using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork_API.Contracts;
using HomeWork_API.Services.Interfaces;

namespace HomeWork_API
{
    public class AppendUserConsumer : IConsumer<AppendUserContract>
    {
        private readonly IUserInfoService _userInfoService;
        public AppendUserConsumer(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public async Task Consume(ConsumeContext<AppendUserContract> context)
        {
            await Console.Out.WriteLineAsync($"Append user to database: {context.Message.user}");

            // update the customer address

            await _userInfoService.AppendUser(context.Message.user);
        }
    }
}
