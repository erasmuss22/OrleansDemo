using Orleans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces.Grains
{
    public interface ITruckGrain : IGrainWithStringKey
    {
        Task UpdateCurrentLocation(string location);

        Task<string> GetCurrentLocation();

        Task CreatePayload(IEnumerable<string> orderNumbers);

        Task<IEnumerable<IPostalOrderGrain>> GetPostalOrders();
    }
}
