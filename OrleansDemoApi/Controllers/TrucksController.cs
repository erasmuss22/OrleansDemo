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
    public class TrucksController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public async Task<int> Get(int id)
        {
            IGrain1 grain = Grain1Factory.GetGrain(Guid.NewGuid());
            return await grain.GetSquaredValue(id);
        }

        [HttpPost]
        [Route("api/trucks")]
        public async Task Post([FromBody]Dictionary<string, string> initialLocationByLicensePlate)
        {
            List<Task> createTruckTasks = new List<Task>();
            foreach (string licensePlate in initialLocationByLicensePlate.Keys)
            {
                ITruck truckGrain = TruckFactory.GetGrain(licensePlate);
                createTruckTasks.Add(truckGrain.UpdateCurrentLocation(initialLocationByLicensePlate[licensePlate]));
            }

            await Task.WhenAll(createTruckTasks);
        }

        [HttpPost]
        [Route("api/trucks/createPayload/{licensePlate}")]
        public async Task PostCreatePayload(string licensePlate, [FromBody]IEnumerable<string> orderNumbers)
        {
            ITruck truckGrain = TruckFactory.GetGrain(licensePlate);
            await truckGrain.CreatePayload(orderNumbers);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/trucks/{license}")]
        public async Task Put(string license, [FromBody]string location)
        {
            ITruck truckGrain = TruckFactory.GetGrain(license);
            await truckGrain.UpdateCurrentLocation(location);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
