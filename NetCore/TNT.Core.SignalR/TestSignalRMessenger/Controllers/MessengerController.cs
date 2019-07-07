using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace TestSignalRMessenger.Controllers
{
    [Route("api/messenger")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        protected IHubContext<Hub<IMessengerClient>, IMessengerClient> _hubContext;
        public MessengerController(IHubContext<Hub<IMessengerClient>, IMessengerClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        [Authorize]
        public async Task Send(SendMessage message)
        {
            await _hubContext.Clients.User(message.ToUserId).ReceiveAsync(new ReceiveMessage()
            {
                Content = message.Content,
                FromUserId = User.Identity.Name,
                Time = DateTime.Now
            });
        }
    }

    public class ReceiveMessage
    {
        public string Content { get; set; }
        public string FromUserId { get; set; }
        public DateTime Time { get; set; }
    }

    public class SendMessage
    {
        public string Content { get; set; }
        public string ToUserId { get; set; }
    }

    public interface IMessengerClient
    {
        Task ReceiveAsync(ReceiveMessage mess);
    }

}
