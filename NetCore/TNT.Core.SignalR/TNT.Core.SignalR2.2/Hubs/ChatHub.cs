using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNT.Core.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }

        [HubMethodName("SendMessage")]
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //throw new HubException("Unmodified exception");
        }

        public async Task SendMessageToCaller(string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessageToGroup(string message)
        {
            await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", message);
        }
    }
}
