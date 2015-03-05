using OrleansDemo.GrainClasses.Models;
using OrleansDemo.GrainInterfaces.Grains;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrleansDemoApi.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Route("api/orders/{orderNumber}/location")]
        public async Task<string> GetLocation(string orderNumber)
        {
            IPostalOrderGrain orderGrain = PostalOrderGrainFactory.GetGrain(orderNumber);
            return await orderGrain.GetTruckLocation();
        }

        [HttpGet]
        [Route("api/orders/{orderNumber}/status")]
        public async Task<string> GetStatus(string orderNumber)
        {
            IPostalOrderGrain orderGrain = PostalOrderGrainFactory.GetGrain(orderNumber);
            return await orderGrain.GetCurrentStatus();
        }

        [HttpPost]
        public async Task Post([FromBody]IEnumerable<Order> orders)
        {
            List<Task> createOrderTasks = new List<Task>();
            foreach (Order order in orders)
            {
                IPostalOrderGrain postalOrderGrain = PostalOrderGrainFactory.GetGrain(order.OrderNumber);
                createOrderTasks.Add(postalOrderGrain.CreateOrder(order.Cost, order.Name));
            }

            await Task.WhenAll(createOrderTasks);
        }
    }
}
