using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleChat.SignalR.Hubs
{
    [HubName("chatHub")] // made it pascal case to make the proxy recognize it => because the proxy is the intermediate between js and C# and he can recognzie the names in camelcase not pascal
    public class ChatHub : Hub
    {
        [HubMethodName("sendMessage")] // made it pascal case to make the proxy recognize it => because the proxy is the intermediate between js and C# and he can recognzie the names in camelcase not pascal
        public void SendMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);

            // here u can store the message in a database
        }
    }
}