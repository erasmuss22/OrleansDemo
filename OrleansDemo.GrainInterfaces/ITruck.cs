using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces
{
    public interface ITruck : IGrainWithStringKey
    {
        Task UpdateCurrentLocation(string location);

        Task<string> GetCurrentLocation();

        Task CreatePayload(IEnumerable<string> orderNumbers);

        Task<IEnumerable<IPostalOrder>> GetPostalOrders();
    }
}
