using Orleans;
using System.Threading.Tasks;

namespace OrleansDemo.GrainInterfaces
{
    /// <summary>
    /// Grain interface IGrain1
    /// </summary>
    public interface IGrain1 : IGrain
    {
        Task<int> GetSquaredValue(int input);
    }
}
