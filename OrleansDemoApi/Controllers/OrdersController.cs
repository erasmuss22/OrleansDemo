using OrleansDemo.GrainClasses;
using OrleansDemo.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrleansDemoApi.Controllers
{
    public class OrdersController : ApiController
    {
        // GET api/values/blah
        [HttpGet]
        [Route("api/orders/{orderNumber}/location")]
        public async Task<string> GetLocation(string orderNumber)
        {
            IPostalOrder orderGrain = PostalOrderFactory.GetGrain(orderNumber);
            return await orderGrain.GetTruckLocation();
        }

        [HttpGet]
        [Route("api/orders/{orderNumber}/status")]
        public async Task<string> GetStatus(string orderNumber)
        {
            IPostalOrder orderGrain = PostalOrderFactory.GetGrain(orderNumber);
            return await orderGrain.GetCurrentStatus();
        }

        // POST api/values
        public async Task Post([FromBody]IEnumerable<Order> orders)
        {
            List<Task> createOrderTasks = new List<Task>();
            foreach (Order order in orders)
            {
                IPostalOrder postalOrderGrain = PostalOrderFactory.GetGrain(order.OrderNumber);
                createOrderTasks.Add(postalOrderGrain.CreateOrder(order.Cost, order.Name));
            }

            await Task.WhenAll(createOrderTasks);
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
