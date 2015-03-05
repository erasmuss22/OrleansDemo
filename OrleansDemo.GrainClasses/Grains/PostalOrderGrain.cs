using Orleans;
using Orleans.Providers;
using OrleansDemo.GrainInterfaces.Grains;
using System.Threading.Tasks;

namespace OrleansDemo.GrainClasses.Grains
{
    [StorageProvider(ProviderName = "AzureStore")]
    public class PostalOrderGrain : Grain<IPostalOrderState>, IPostalOrderGrain
    {
        public override Task OnActivateAsync()
        {
            this.State.Status = "Created";
            this.State.Cost = 0;
            return base.OnActivateAsync();
        }

        public async Task UpdateShippingStatus(string status, ITruckGrain truck)
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
            await this.State.WriteStateAsync();
        }
    }

    public interface IPostalOrderState : IGrainState
    {
        string Name { get; set; }

        ITruckGrain Truck { get; set; }
        
        string Status { get; set; }
        
        int Cost { get; set; }
    }
}
