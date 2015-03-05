using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using OrleansDemo.GrainInterfaces;
using Orleans.Providers;

namespace OrleansDemo.GrainClasses
{
    [StorageProvider(ProviderName = "AzureStore")]
    public class TruckGrain : Grain<ITruckState>, ITruck
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
            List<IPostalOrder> postalOrderGrains = new List<IPostalOrder>();

            // add the orders to the truck in parallel
            foreach (string orderNumber in orderNumbers)
            {
                IPostalOrder orderGrain = PostalOrderFactory.GetGrain(orderNumber);
                postalOrderGrains.Add(orderGrain);
                addOrderToTruckTasks.Add(orderGrain.UpdateShippingStatus("Shipped", this));
            }

            // wait for the orders to be added to the truck
            await Task.WhenAll(addOrderToTruckTasks);

            this.State.PostalOrders = postalOrderGrains;

            await this.State.WriteStateAsync();
        }

        public async Task<IEnumerable<IPostalOrder>> GetPostalOrders()
        {
            await this.State.ReadStateAsync();
            return this.State.PostalOrders;
        }
    }

    public interface ITruckState : IGrainState
    {
        string Location { get; set; }

        IEnumerable<IPostalOrder> PostalOrders { get; set; }
    }
}
