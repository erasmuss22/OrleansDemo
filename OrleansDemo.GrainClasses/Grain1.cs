using Orleans;
using OrleansDemo.GrainInterfaces;
using System.Threading.Tasks;

namespace OrleansDemo.GrainClasses
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class Grain1 : Grain, IGrain1
    {
        public async Task<int> GetSquaredValue(int input)
        {
            return await Task<int>.FromResult(input * input);
        }
    }
}
