using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces
{
    public interface IPostalOrder : IGrainWithStringKey
    {
        Task UpdateShippingStatus(string status, ITruck truck);

        Task<string> GetCurrentStatus();

        Task<string> GetTruckLocation();

        Task CreateOrder(int cost, string name);
    }
}
