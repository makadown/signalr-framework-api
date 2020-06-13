using Microsoft.AspNet.SignalR;
using SignalR.Framework.Test.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalR.Framework.Test.Controllers
{
    public class ValuesController : ApiController
    {
        private IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        // GET api/values
        public async Task<IEnumerable<string>> Get([FromUri] string token)
        {
            await _hub.Clients.Client(token).SendMessage("Inicio proceso Dummy");
            Thread.Sleep(1000);
            await _hub.Clients.Client(token).SendMessage("Simulo que hago algo");
            Thread.Sleep(2000);
            await _hub.Clients.Client(token).SendMessage("Enviando los valores");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
