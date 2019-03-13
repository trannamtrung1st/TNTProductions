using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using TNT.Core.SignalR.Hubs;

namespace TNT.Core.SignalR.Pages
{
    public class IndexModel : PageModel
    {
        private IHubContext<ChatHubStrongTyped, IChatClient> _hubContext;
        public IndexModel(IHubContext<ChatHubStrongTyped, IChatClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public void OnGet()
        {
        }

        //?handler=Abc
        public void OnGetAbc()
        {
            _hubContext.Clients.All.ReceiveMessage("TNT", "OKOK");
        }
    }
}
