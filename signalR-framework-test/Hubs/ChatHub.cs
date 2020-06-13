using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalR.Framework.Test.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        /// <summary>
        /// envia mensaje al conectar WS
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnected()
        {
            await Clients.Caller.SendAsync("Conexión exitosa", Context.User.Identity.Name, "joined");
        }
        /// <summary>
        /// envia mensaje al desconectar WS
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override async Task OnDisconnected(bool stopCalled)
        {
            await Clients.Caller.SendAsync("Desconexión exitosa", Context.User.Identity.Name, "left");
        }
        /// <summary>
        /// envia mensaje
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Send(string message)
        {
            await Clients.Caller.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }

        public async Task PruebaMayito(string message)
        {
            await Clients.Caller.SendAsync("PruebaMayito", Context.User.Identity.Name, message);
        }
    }
}