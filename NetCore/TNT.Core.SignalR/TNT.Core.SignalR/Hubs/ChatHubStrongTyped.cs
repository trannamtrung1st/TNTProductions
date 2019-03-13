using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNT.Core.SignalR.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
        Task ReceiveMessage(string message);
    }

    public class ChatHubStrongTyped : Hub<IChatClient>
    {

        public ChatHubStrongTyped()
        {
        }

        [Authorize]
        [HubMethodName("SendMessage")]
        public async Task SendMessage(string user, string message)
        {
            var id = Context.UserIdentifier;
            await Clients.User("TNT").ReceiveMessage("System", "You're the one");
            await Clients.All.ReceiveMessage(user, message);
        }

        public async Task SendMessageToCaller(string message)
        {
            await Clients.Caller.ReceiveMessage(message);
        }

        public async Task SendMessageToGroup(string message)
        {
            await Clients.Group("SignalR Users").ReceiveMessage(message);
        }

    }
}
