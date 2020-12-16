using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemotePresentationUsingSgnalR.Server.Hubs
{
    public class SignalHub : Hub
    {
        public async Task SendMessage(string type, string data)
        {
            await Clients.All.SendAsync("ReceiveMessage", type, data);
        }
        public async Task SendPage(string hash, int num)
        {
            await Clients.All.SendAsync("ReceivePage", hash, num);
        }
        public async Task SendConnectSignal(string hash, bool isConn)
        {
            await Clients.All.SendAsync("ReceiveConnSignal", hash, isConn);
        }
        public async Task SendFullScreenSignal(string hash, bool isFullScreen)
        {
            await Clients.All.SendAsync("ReceiveFullScreenSignal", hash, isFullScreen);
        }
        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    await Clients.All.SendAsync("ReceiveConnSignal", false);
        //    await base.OnDisconnectedAsync(exception);
        //}

    }
}