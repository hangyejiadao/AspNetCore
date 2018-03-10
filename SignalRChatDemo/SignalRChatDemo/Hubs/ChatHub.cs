using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace SignalRChatDemo.Hubs
{
    public class ChatHub:Hub
    {
        public Task Send(string user, string message)
        {
            string timestamp = DateTime.Now.ToShortTimeString();
            return Clients.All.SendAsync(timestamp, user, message);
        }
      

    }
}
