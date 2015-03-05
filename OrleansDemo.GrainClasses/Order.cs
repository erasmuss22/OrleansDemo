using OrleansDemo.GrainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.GrainClasses
{
    public class Order : IOrder
    {
        public string OrderNumber { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }
    }
}
