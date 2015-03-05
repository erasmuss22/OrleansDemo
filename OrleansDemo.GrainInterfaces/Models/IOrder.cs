namespace OrleansDemo.GrainInterfaces.Models
{
    public interface IOrder
    {
        string OrderNumber { get; set; }

        int Cost { get; set; }
        
        string Name { get; set; }
    }
}
