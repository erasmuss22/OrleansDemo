using Orleans;
using Orleans.Providers;
using OrleansDemo.GrainInterfaces.Grains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrleansDemo.GrainClasses.Grains
{
    [StorageProvider(ProviderName = "AzureStore")]
    public class TruckGrain : Grain<ITruckState>, ITruckGrain
    {
        public async Task UpdateCurrentLocation(string location)
        {
            this.State.Location = location;
            await this.State.WriteStateAsync();
        }

        public async Task<string> GetCurrentLocation()
        {
            await this.State.ReadStateAsync();
            return this.State.Location;
        }

        public async Task CreatePayload(IEnumerable<string> orderNumbers)
        {
            List<Task> addOrderToTruckTasks = new List<Task>();
            List<IPostalOrderGrain> postalOrderGrains = new List<IPostalOrderGrain>();

            // add the orders to the truck in parallel
            foreach (string orderNumber in orderNumbers)
            {
                IPostalOrderGrain orderGrain = PostalOrderGrainFactory.GetGrain(orderNumber);
                postalOrderGrains.Add(orderGrain);
                addOrderToTruckTasks.Add(orderGrain.UpdateShippingStatus("Shipped", this));
            }

            // wait for the orders to be added to the truck
            await Task.WhenAll(addOrderToTruckTasks);

            this.State.PostalOrders = postalOrderGrains;

            await this.State.WriteStateAsync();
        }

        public async Task<IEnumerable<IPostalOrderGrain>> GetPostalOrders()
        {
            await this.State.ReadStateAsync();
            return this.State.PostalOrders;
        }
    }

    public interface ITruckState : IGrainState
    {
        string Location { get; set; }

        IEnumerable<IPostalOrderGrain> PostalOrders { get; set; }
    }
}
