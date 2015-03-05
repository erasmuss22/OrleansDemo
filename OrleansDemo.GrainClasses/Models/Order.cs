using OrleansDemo.GrainInterfaces.Models;

namespace OrleansDemo.GrainClasses.Models
{
    public class Order : IOrder
    {
        public string OrderNumber { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }
    }
}
