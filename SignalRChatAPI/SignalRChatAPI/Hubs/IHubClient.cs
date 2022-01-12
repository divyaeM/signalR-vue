﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatAPI.Hubs
{
    public interface IHubClient
    {
        Task ReceiveMessage(string username, string message);

        Task SendMessage(string username, string message);
    }
}
