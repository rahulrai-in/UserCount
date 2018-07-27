namespace ChatRWeb
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class UserCount : Hub
    {
        private static int Count;

        public override Task OnConnectedAsync()
        {
            Count++;
            base.OnConnectedAsync();
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;
            base.OnDisconnectedAsync(exception);
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }
    }
}