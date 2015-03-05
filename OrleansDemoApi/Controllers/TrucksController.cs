using OrleansDemo.GrainInterfaces.Grains;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrleansDemoApi.Controllers
{
    public class TrucksController : ApiController
    {
        [HttpPost]
        [Route("api/trucks")]
        public async Task Post([FromBody]Dictionary<string, string> initialLocationByLicensePlate)
        {
            List<Task> createTruckTasks = new List<Task>();
            foreach (string licensePlate in initialLocationByLicensePlate.Keys)
            {
                ITruckGrain truckGrain = TruckGrainFactory.GetGrain(licensePlate);
                createTruckTasks.Add(truckGrain.UpdateCurrentLocation(initialLocationByLicensePlate[licensePlate]));
            }

            await Task.WhenAll(createTruckTasks);
        }

        [HttpPost]
        [Route("api/trucks/createPayload/{licensePlate}")]
        public async Task PostCreatePayload(string licensePlate, [FromBody]IEnumerable<string> orderNumbers)
        {
            ITruckGrain truckGrain = TruckGrainFactory.GetGrain(licensePlate);
            await truckGrain.CreatePayload(orderNumbers);
        }

        [HttpPut]
        [Route("api/trucks/{license}")]
        public async Task Put(string license, [FromBody]string location)
        {
            ITruckGrain truckGrain = TruckGrainFactory.GetGrain(license);
            await truckGrain.UpdateCurrentLocation(location);
        }
    }
}
