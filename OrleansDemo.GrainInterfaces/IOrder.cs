using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces
{
    public interface IOrder
    {
        string OrderNumber { get; set; }

        int Cost { get; set; }
        
        string Name { get; set; }
    }
}
