using Orleans;
using Orleans.Providers;
using OrleansDemo.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.GrainClasses
{
    [StorageProvider(ProviderName = "AzureStore")]
    public class PostalOrderGrain : Grain<IPostalOrderState>, IPostalOrder
    {
        public async Task UpdateShippingStatus(string status, ITruck truck)
        {
            this.State.Status = status;
            this.State.Truck = truck;
       
            await this.State.WriteStateAsync();
        }

        public async Task<string> GetCurrentStatus()
        {
            return await Task<string>.FromResult(this.State.Status);
        }

        public async Task<string> GetTruckLocation()
        {
            if (this.State.Truck != null)
            {
                return await this.State.Truck.GetCurrentLocation();
            }

            return null;
        }

        public async Task CreateOrder(int cost, string name)
        {
            this.State.Name = name;
            this.State.Cost = cost;
            this.State.Status = "Created";
            await this.State.WriteStateAsync();
        }
    }

    public interface IPostalOrderState : IGrainState
    {
        string Name { get; set; }
        ITruck Truck { get; set; }
        string Status { get; set; }
        int Cost { get; set; }
    }
}
