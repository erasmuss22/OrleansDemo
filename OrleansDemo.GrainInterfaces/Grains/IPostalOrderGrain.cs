using Orleans;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces.Grains
{
    public interface IPostalOrderGrain : IGrainWithStringKey
    {
        Task UpdateShippingStatus(string status, ITruckGrain truck);

        Task<string> GetCurrentStatus();

        Task<string> GetTruckLocation();

        Task CreateOrder(int cost, string name);
    }
}
