using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRChatAPI.Models;
using SignalRChatAPI.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChatAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private IHubContext<ChatHub, IHubClient> _chatHub;
        public ValuesController(IHubContext<ChatHub, IHubClient> hubContext)
        {
                _chatHub = hubContext;
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Chat chat)
        {
            await _chatHub.Clients.All.ReceiveMessage(chat.Username, chat.Message);
        }
    }
}
