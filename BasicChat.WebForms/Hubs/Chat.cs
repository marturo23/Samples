using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using BasicChat.WebForms.Models;

namespace BasicChat.WebForms
{
    public class Chat : Hub
    {
        public void Send(string message)
        {
            ChatDb.Add(message);
            Clients.All.send(message);
        }
    }
}